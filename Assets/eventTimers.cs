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
    public bool paintingsOn;
    public float transitionTimer = 30f;
    public float musicTimer = 20f;
    public float resetTimer = 390f;
    public float alarmTimer = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StopAllCoroutines();
        paintingsOn = GetComponent<SensorLogic>().areAllPaintingsOn;

        if (paintingsOn == true)
        {
            linealSequenceCorroutine = StartCoroutine(coroutine(transitionTimer, alarmTimer, musicTimer, resetTimer));
            Debug.Log("Coroutine started");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator coroutine(float toTransition,float toAlarm, float toMusic, float toReset)
    {
        //Seconds before launching the transition
        yield return new WaitForSeconds(toTransition);
        AkUnitySoundEngine.PostEvent("Transition", gameObject);
        Debug.Log("Transition event launched");

        //Seconds before launching the alarm
        yield return new WaitForSeconds(toAlarm);
        AkUnitySoundEngine.PostEvent("Alarm", gameObject);
        Debug.Log("Alarm event launched");

        //waits for the alarm to finish to launch the music
        yield return new WaitForSeconds(toMusic);
        AkUnitySoundEngine.PostEvent("Music", gameObject);
        Debug.Log("Music event launched");

        //waits for the music to finish to reset everything
        yield return new WaitForSeconds(toReset);
        AkUnitySoundEngine.PostEvent("Reset", gameObject);
        Debug.Log("Reset event launched");

        //Resets all the booleans to false
        GetComponent<SensorLogic>().isPaintingOn[0] = false;
        GetComponent<SensorLogic>().isPaintingOn[1] = false;
        GetComponent<SensorLogic>().isPaintingOn[2] = false;
        GetComponent<SensorLogic>().areAllPaintingsOn = false;
    }

}
