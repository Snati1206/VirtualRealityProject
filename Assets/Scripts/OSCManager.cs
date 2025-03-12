using UnityEngine;
using extOSC;
using System;

public class OSCManager : MonoBehaviour

{
    public string networkIP = "192.168.0.164";
    public int port = 9999;
    [SerializeField] public static float sensor1;
    [SerializeField] public static float sensor2;
    [SerializeField] public static float sensor3;
    public bool oscOn = false;

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
        Debug.Log("Sensor 1: " + sensor1);
        Debug.Log("Sensor 2: " + sensor2);
        Debug.Log("Sensor 3: " + sensor3);
    }

    private void OnReceiveSensor1(OSCMessage message)
    {

        if (message.ToFloat(out float value))
        {
            sensor1 = value;
        }
        else
        {
            sensor1 = 100f;
            Debug.LogError("OSC message out borders.");
        }
    }

    private void OnReceiveSensor2(OSCMessage message)
    {
        if (message.ToFloat(out float value))
        {
            sensor2 = value;
        }
         else
        {
            sensor2 = 100f;
            Debug.LogError("OSC message out borders.");
        }
    }

    private void OnReceiveSensor3(OSCMessage message)
    {
        Debug.Log("Sensor 3: " + message);
        if (message.ToFloat(out float value))
        {
            sensor3 = value;

        }
        else
        {
            sensor3 = 100f;
            Debug.LogError("OSC message out borders.");
        }

    }
}
