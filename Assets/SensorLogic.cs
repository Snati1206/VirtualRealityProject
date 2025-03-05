using UnityEngine;
using UnityEngine.InputSystem;

public class SensorLogic : MonoBehaviour
{
    public OSCManager oscManager;
    public bool isPaint1On = false;
    public bool isPaint2On = false;
    public bool isPaint3On = false;
    public bool areAllPaintingsOn = false;

    private float currentTime1 = 0f;
    private float currentTime2 = 0f;
    private float currentTime3 = 0f;


    [SerializeField] private bool Event1Triggered = false;
    [SerializeField] private bool Event2Triggered = false;
    [SerializeField] private bool Event3Triggered = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (oscManager == null)
        {
            Debug.LogError("OSCManager not initialized.");
            return;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        sensorActivated(oscManager, 5f, 14f, 5f);
        if (isPaint1On && isPaint2On && isPaint3On)
        {
            areAllPaintingsOn = true;
        }
        else
        {
            areAllPaintingsOn = false;
        }
        
    }

    void sensorActivated(OSCManager oscManager,  float minDistance, float maxDistance, float time)
    {
        //Values from the sensors and bools to check if the event has been triggered    
        float sensor1 = oscManager.sensor1;
        float sensor2 = oscManager.sensor2;
        float sensor3 = oscManager.sensor3;



       //Logic to activate the sensors and post the Wwise event only once 
        if (oscManager == null)
        {
            Debug.LogError("OSCManager not initialized.");
            return;
        }
        else
        {
            //Sensor 1 Logic
            if (sensor1 >= minDistance && sensor1 <= maxDistance)
            {
                currentTime1 += Time.deltaTime;
                if (currentTime1 >= time)
                {
                    isPaint1On = true;
                    if (!Event1Triggered)
                    {
                        AkUnitySoundEngine.PostEvent("Sensor1Activated", gameObject);
                        Event1Triggered = true;
                    }
                }
            }
            else
            {
            //    isPaint1On = false;
                currentTime1 = 0f;
            //    Event1Triggered = false;
            }

            //Sensor 2 Logic
            if (sensor2 >= minDistance && sensor2 <= maxDistance)
            {
                currentTime2 += Time.deltaTime;
                if (currentTime2 >= time)
                {
                    isPaint2On = true;
                    if (!Event2Triggered)
                    {
                        AkUnitySoundEngine.PostEvent("Sensor2Activated", gameObject);
                        Event2Triggered = true;
                    }

                }
            }
            else
            {
            //    isPaint2On = false;
                currentTime2 = 0f;
            //    Event2Triggered = false;
            }

            //Sensor 3 Logic
            if (sensor3 >= minDistance && sensor3 <= maxDistance)
            {
                currentTime3 += Time.deltaTime;
                if (currentTime3 >= time)
                {
                    isPaint3On = true;
                    if (!Event3Triggered)
                    {
                        AkUnitySoundEngine.PostEvent("Sensor3Activated", gameObject);
                        Event3Triggered = true;
                    }
                }
            }
            else
            {
            //    isPaint3On = false;
                currentTime3 = 0f;
            //    Event3Triggered = false;
            }
        
            
        }
        return;
    }
}
