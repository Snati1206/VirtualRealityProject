using UnityEngine;
using extOSC;
using System;
using System.Collections.Generic;
using System.Linq;

public class OSCManager : MonoBehaviour

{
    public string networkIP = "192.168.0.164";
    public int port = 9999;
    public static float sensor1;
    public static float sensor2;
    public static float sensor3;
    public bool oscOn = false;

    [Header("Lists")]
    private List<float> sensor1Values = new List<float>();
    private List<float> sensor2Values = new List<float>();
    private List<float> sensor3Values = new List<float>();
    public int maxSizeList = 5;

    private OSCReceiver receiver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        receiver = gameObject.AddComponent<OSCReceiver>();
        receiver.LocalHost = networkIP;
        receiver.LocalPort = port;
        receiver.Bind("/distance/1", OnReceiveSensor1);
        receiver.Bind("/distance/2", OnReceiveSensor2);
        receiver.Bind("/distance/3", OnReceiveSensor3);
        Debug.Log("OSC Receiver initialized with IP: " + networkIP + " and Port: " + port);
    }

    // Update is called once per frame
    void Update()
    {     
        // Calculate the sensors average value

        sensor1 = CalculateAverage(sensor1Values);
        sensor2 = CalculateAverage(sensor2Values);
        sensor3 = CalculateAverage(sensor3Values);
        
        Debug.Log("Sensor 1: " + sensor1);
        Debug.Log("Sensor 2: " + sensor2);
        Debug.Log("Sensor 3: " + sensor3);
    }

    private void OnReceiveSensor1(OSCMessage message)
    {

        if (message.ToFloat(out float value))
        {
            if (value > 100f)
            {
                value = 100f;
            }
            if (value < 3f)
            {
                value = 3f;
            }
            AddValueList(sensor1Values, value);
        }
        else
        {
            Debug.LogError("OSC message out borders.");
        }
    }

    private void OnReceiveSensor2(OSCMessage message)
    {
        if (message.ToFloat(out float value))
        {
            if (value > 100f)
            {
                value = 100f;
            }
            if (value < 3f)
            {
                value = 3f;
            }
            AddValueList(sensor2Values, value);          
        }
         else
        {
            Debug.LogError("OSC message out borders.");
        }
    }

    private void OnReceiveSensor3(OSCMessage message)
    {
        Debug.Log("Sensor 3: " + message);
        if (message.ToFloat(out float value))
        {
            if (value > 100f)
            {
                value = 100f;
            }
            if (value < 3f)
            {
                value = 3f;
            }
            AddValueList(sensor3Values, value);

        }
        else
        {
            Debug.LogError("OSC message out borders.");
        }

    }

    private void AddValueList(List<float> valuesAvg, float value)
    {
        valuesAvg.Add(value);
        if (valuesAvg.Count > maxSizeList)
        {
            valuesAvg.RemoveAt(0);
        }
    }

    private float CalculateAverage(List<float> values)
    {
        if (values.Count == 0)
        {
            return 0;
        }

        return values.Average();
    }
}
