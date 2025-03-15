using UnityEngine;
using extOSC;
using System;
using System.Collections.Generic;
using System.Linq;

public class OSCManager : MonoBehaviour

{
    [Header("OSC Settings")]
//    public string networkIP = "192.168.0.164";
//    public int port = 9999;
    public static float sensor1;
    public static float sensor2;
    public static float sensor3;
//    public bool oscOn = false;

    [Header("Xbox Controller Settings")]
    private float xButtonValue;
    private float bButtonValue;
    private float yButtonValue;

    [Header("Lists")]
//    private List<float> sensor1Values = new List<float>();
//    private List<float> sensor2Values = new List<float>();
//    private List<float> sensor3Values = new List<float>();
//    public int maxSizeList = 5;

    private OSCReceiver receiver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
#region OSC Initialization
//        receiver = gameObject.AddComponent<OSCReceiver>();
//        receiver.LocalHost = networkIP;
//        receiver.LocalPort = port;
//        receiver.Bind("/distance/1", OnReceiveSensor1);
//        receiver.Bind("/distance/2", OnReceiveSensor2);
//        receiver.Bind("/distance/3", OnReceiveSensor3);
//        Debug.Log("OSC Receiver initialized with IP: " + networkIP + " and Port: " + port);
#endregion

    }

    // Update is called once per frame
    void Update()
    { 
#region OSC Update            
        // Calculate the sensors average value

//        sensor1 = CalculateAverage(sensor1Values);
//        sensor2 = CalculateAverage(sensor2Values);
//        sensor3 = CalculateAverage(sensor3Values);       
    //    Debug.Log("Sensor 1: " + sensor1);
    //    Debug.Log("Sensor 2: " + sensor2);
    //    Debug.Log("Sensor 3: " + sensor3);
#endregion
        sensor1 = 100f - XboxController.xButtonValue;
        sensor2 = 100f - XboxController.bButtonValue;
        sensor3 = 100f - XboxController.yButtonValue;


    }

#region OSC Methods
//    private void OnReceiveSensor1(OSCMessage message)
//    {
//
//        if (message.ToFloat(out float value))
//        {
//            if (value > 100f)
//            {
//                value = 100f;
//            }
//            AddValueList(sensor1Values, value);
//        }
//        else
//        {
//            Debug.LogError("OSC message out borders.");
//        }
//    }
//
//    private void OnReceiveSensor2(OSCMessage message)
//    {
//        if (message.ToFloat(out float value))
//        {
//            if (value > 100f)
//            {
//                value = 100f;
//            }
//
//            AddValueList(sensor2Values, value);          
//        }
//         else
//        {
//            Debug.LogError("OSC message out borders.");
//        }
//    }
//
//    private void OnReceiveSensor3(OSCMessage message)
//    {
//
//        if (message.ToFloat(out float value))
//        {
//            if (value > 100f)
//            {
//                value = 100f;
//            }
//
//            AddValueList(sensor3Values, value);
//
//        }
//        else
//        {
//            Debug.LogError("OSC message out borders.");
//        }
//
//    }
//
//    private void AddValueList(List<float> valuesAvg, float value)
//    {
//        valuesAvg.Add(value);
//        if (valuesAvg.Count > maxSizeList)
//        {
//            valuesAvg.RemoveAt(0);
//        }
//    }
//
//    private float CalculateAverage(List<float> values)
//    {
//        if (values.Count == 0f)
//        {
//            return 100f;
//        }
//
//        return values.Average();
//    }
#endregion
}
