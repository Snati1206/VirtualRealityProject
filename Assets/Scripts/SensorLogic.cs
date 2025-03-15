using System;
using AK.Wwise;
using UnityEngine;
using UnityEngine.InputSystem;

public class SensorLogic : MonoBehaviour
{
    public bool[] isPaintingOn = new bool[3] { false, false, false };
    public bool[] eventTriggered = new bool[3] { false, false, false };
    public static bool areAllPaintingsOn = false;
    private string[] wwisePaintsOn = new string[3] { "Sensor1Activated", "Sensor2Activated", "Sensor3Activated" };
    private string[] wwisePaintsOff = new string[3] { "StopSensor1", "StopSensor2", "StopSensor3" };
    public static event Action OnAllPaintingsOn;
    private float[] currentTime = new float[3] { 0f, 0f, 0f };


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Calling the SensorActivated function for each sensor that sends data between 10 and 15 cm for 5 seconds
        SensorActivated(0, OSCManager.sensor1, 0f, 5f, 3f);
        SensorActivated(1, OSCManager.sensor2, 0f, 5f, 3f);
        SensorActivated(2, OSCManager.sensor3, 0f, 5f, 3f);

        //Checking if a painting has been activated to stop the sensor loop in wwise
    //    DeactivatePortal(0);
    
    //    DeactivatePortal(1);
    //    DeactivatePortal(2);    

        if (isPaintingOn[0] == true && isPaintingOn[1] == true && isPaintingOn[2] == true && !areAllPaintingsOn)
        {
            areAllPaintingsOn = true;
            Debug.Log("All paintings are on");
            OnAllPaintingsOn?.Invoke(); // Triggers the eventTimers coroutine
        }
     
    }

    void SensorActivated(int index, float sensor,  float minDistance, float maxDistance, float time)
    {
        if (sensor >= minDistance && sensor <= maxDistance)
        {
            currentTime[index] += Time.deltaTime;
            if (currentTime[index] >= time)
            {
                isPaintingOn[index] = true;
                if (!eventTriggered[index])
                {
                    AkUnitySoundEngine.PostEvent(wwisePaintsOn[index], gameObject);
                    eventTriggered[index] = true;
                    currentTime[index] = 0f;
                }
            }
        }
        else
        {
        //    isPaint1On = false;
            currentTime[index] = 0f;
        //    Event1Triggered = false;
        }    
        return;
    }

    
    //Method to deactivate a portal after it has been activated
    public void DeactivatePortal(int index)
    {
        isPaintingOn[index] = false;
        eventTriggered[index] = true;
        AkUnitySoundEngine.PostEvent(wwisePaintsOff[index], gameObject);
    }

}
