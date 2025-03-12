using System;
using System.Collections.Generic;
using UnityEngine;

public class Parameters : MonoBehaviour
{
    public static float[] rtpcs = new float[3];

    [SerializeField] public Dictionary<string, float> sensorValuesDict = new Dictionary<string, float>();
 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Storing the sensor values in cache
        sensorValuesDict["sensor1"] = OSCManager.sensor1;
        sensorValuesDict["sensor2"] = OSCManager.sensor2;
        sensorValuesDict["sensor3"] = OSCManager.sensor3;

        //Starting Audio Event

        AkUnitySoundEngine.PostEvent("Init", gameObject);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // Updating the sensor values
        sensorValuesDict["sensor1"] = OSCManager.sensor1;
        sensorValuesDict["sensor2"] = OSCManager.sensor2;
        sensorValuesDict["sensor3"] = OSCManager.sensor3;

        // Calling the method to update the RTPCs
        RtpcUpdate(rtpcs);   
    }

    void RtpcUpdate (float[] paramArrays)
    {
        // Assigning the sensor's values to the dictionary
        int i = 0;
        foreach (var sensor in sensorValuesDict)
        {
            paramArrays[i] = sensor.Value;
            AkUnitySoundEngine.SetRTPCValue(sensor.Key, paramArrays[i]);
            i++;
            
        }
    }

    public void WeirdRtpcUpdate (float paramValue)
    {
        // Assigning the value to the ActivationStatus RTPC in Wwise
        AkUnitySoundEngine.SetRTPCValue("ActivationStatus", paramValue);
    }
}
