using AK.Wwise;
using UnityEngine;
using UnityEngine.InputSystem;

public class SensorLogic : MonoBehaviour
{
    public OSCManager oscManager;
    public bool[] isPaintingOn = new bool[3] { false, false, false };
    public bool[] eventTriggered = new bool[3] { false, false, false };
    public bool areAllPaintingsOn = false;
    private float[] currentTime = new float[3] { 0f, 0f, 0f };
    private string[] wwisePaintsOn = new string[3] { "Sensor1Activated", "Sensor2Activated", "Sensor3Activated" };




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (oscManager == null)
        {
            Debug.LogError("OSCManager not assigned.");
            return;
        }
        else
        {
            Debug.Log("OSCManager assigned.");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //Calling the sensorActivated function for each sensor that sends data between 10 and 15 cm for 5 seconds

        sensorActivated(0, oscManager.sensor1, 10f, 15f, 5f);
        sensorActivated(1, oscManager.sensor2, 10f, 15f, 5f);
        sensorActivated(2, oscManager.sensor3, 10f, 15f, 5f);

        if (isPaintingOn[0] == true && isPaintingOn[1] == true && isPaintingOn[2] == true)
        {
            areAllPaintingsOn = true;
        }
        else
        {
            areAllPaintingsOn = false;
        }
        
    }

    void sensorActivated(int index, float sensor,  float minDistance, float maxDistance, float time)
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
}
