using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// This script controls the delays between each main event in the VR experience
// It is responsible for the timing of the events and the activation of the audio and visual effects
// It is also responsible for the reset of everything once it is done



public class EventCoroutine : MonoBehaviour
{
    Coroutine linealSequenceCorroutine;
    LightsControllerRed lightsControllerRed;
    LightsControllerBlue lightsControllerBlue;
    LightsControllerYellow lightsControllerYellow;
    public float transitionTimer = 50f;
    public float musicTimer = 25f;
    public float resetTimer = 60f;
    public float alarmTimer = 5f;
    public static bool transition = false;
    public static bool alarm = false;
    public static bool music = false;
    public static bool reset = false;

    void OnEnable()
    {
        SensorLogic.OnAllPaintingsOn += StartCoroutine;
    }

    void OnDisable()
    {
        SensorLogic.OnAllPaintingsOn -= StartCoroutine;

    }

    void StartCoroutine()
    {
        if (linealSequenceCorroutine == null)
        {
            linealSequenceCorroutine = StartCoroutine(coroutine(transitionTimer, alarmTimer, musicTimer, resetTimer));
            Debug.Log("Coroutine started");
        }
    }


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator coroutine(float toTransition,float toAlarm, float toMusic, float toReset)
    {
        reset = false;
        #region
        //Seconds before launching the transition
        yield return new WaitForSeconds(toTransition);
        AkUnitySoundEngine.PostEvent("Transition", gameObject);
        transition = true;
        Debug.Log("Transition event launched");
        #endregion

        #region
        //Seconds before launching the alarm
        yield return new WaitForSeconds(toAlarm);

        AkUnitySoundEngine.PostEvent("Alarm", gameObject);
        Debug.Log("Alarm event launched");
        alarm = true;
        StopLights();

        #endregion

        #region
        //waits for the alarm to finish to launch the music
        yield return new WaitForSeconds(toMusic);
        AkUnitySoundEngine.PostEvent("Music", gameObject);
        Debug.Log("Music event launched");
        music = true;
        #endregion
        //waits for the music to finish to reset everything
        yield return new WaitForSeconds(toReset);
        AkUnitySoundEngine.PostEvent("Reset", gameObject);
        Debug.Log("Reset event launched");
        reset = true;
        transition = false;
        alarm = false;
        music = false;
        //Resets all the booleans to false
        ResetPaintings();
        ResetLights();
        Debug.Log("All events reseted");
    }

    void ResetPaintings()
    {
        SensorLogic sensorLogic = GetComponent<SensorLogic>();
        if (sensorLogic != null)
        {
            sensorLogic.isPaintingOn[0] = false;
            sensorLogic.isPaintingOn[1] = false;
            sensorLogic.isPaintingOn[2] = false;
            SensorLogic.areAllPaintingsOn = false;
            sensorLogic.eventTriggered[0] = false;
            sensorLogic.eventTriggered[1] = false;
            sensorLogic.eventTriggered[2] = false;
            Debug.Log("Paintings reset");
        }
        else
        {
            Debug.LogError("SensorLogic component not found");
        }

        // Reset the coroutine reference
        linealSequenceCorroutine = null;
        Debug.Log("Coroutine stopped");


    }

    void StopLights()
    {
        if (lightsControllerRed != null && lightsControllerBlue != null && lightsControllerYellow != null)
        {
            lightsControllerRed.luminosity = Mathf.Lerp(lightsControllerRed.luminosity, 0f, Time.deltaTime * 0.005f);
            lightsControllerBlue.luminosity = Mathf.Lerp(lightsControllerBlue.luminosity, 0f, Time.deltaTime * 0.005f);
            lightsControllerYellow.luminosity = Mathf.Lerp(lightsControllerYellow.luminosity, 0f, Time.deltaTime * 0.005f);
            lightsControllerRed.oscillation = Mathf.Lerp(lightsControllerRed.oscillation, 0f, Time.deltaTime * 0.05f);
            lightsControllerBlue.oscillation = Mathf.Lerp(lightsControllerBlue.oscillation, 0f, Time.deltaTime * 0.05f);
            lightsControllerYellow.oscillation = Mathf.Lerp(lightsControllerYellow.oscillation, 0f, Time.deltaTime * 0.05f);
        }
        else
        {
            Debug.LogError("One or more light controllers are not assigned.");
        }
    }

    void ResetLights()
    {
        if (lightsControllerRed != null && lightsControllerBlue != null && lightsControllerYellow != null)
        {
            lightsControllerRed.luminosity = Mathf.Lerp(lightsControllerRed.luminosity, 12f, Time.deltaTime * 0.005f);
            lightsControllerBlue.luminosity = Mathf.Lerp(lightsControllerBlue.luminosity, 12f, Time.deltaTime * 0.005f);
            lightsControllerYellow.luminosity = Mathf.Lerp(lightsControllerYellow.luminosity, 12f, Time.deltaTime * 0.005f);
            lightsControllerRed.oscillation = Mathf.Lerp(lightsControllerRed.oscillation, 1.5f, Time.deltaTime * 0.05f);
            lightsControllerBlue.oscillation = Mathf.Lerp(lightsControllerBlue.oscillation, 2.5f, Time.deltaTime * 0.05f);
            lightsControllerYellow.oscillation = Mathf.Lerp(lightsControllerYellow.oscillation, 2.5f, Time.deltaTime * 0.05f);
        }
        else
        {
            Debug.LogError("One or more light controllers are not assigned.");
        }
    }

}
