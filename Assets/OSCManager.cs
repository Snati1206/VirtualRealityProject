using UnityEngine;
using extOSC;
using System;

public class OSCManager : MonoBehaviour

{
    public string networkIP = "127.0.0.1";
    public int port = 8000;
    public static float sensor1;
    public static float sensor2;
    public static float sensor3;

    public bool oscOn = false;

    private OSCReceiver receiver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        receiver = gameObject.AddComponent<OSCReceiver>();
        receiver.LocalHost = networkIP;
        receiver.LocalPort = port;
        receiver.Bind("/sensor1", OnReceiveSensor1);
        receiver.Bind("/sensor2", OnReceiveSensor2);
        receiver.Bind("/sensor3", OnReceiveSensor3);
        
    }

    // Update is called once per frame
    void Update()
    {        
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
