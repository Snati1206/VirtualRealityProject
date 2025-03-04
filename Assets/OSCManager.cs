using UnityEngine;
using extOSC;

public class OSCManager : MonoBehaviour

{
    public string networkIP = "127.0.0.1";
    public int port = 8000;
    public float sensor1;
    public float sensor2;
    public float sensor3;

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
        if (receiver == null) 
        {
            Debug.LogError("OSCReceiver not initialized.");
            return;
        }

        
    }

    private void OnReceiveSensor1(OSCMessage message)
    {
        if (message.ToFloat(out float value))
        {
            sensor1 = value;
        }
    }

    private void OnReceiveSensor2(OSCMessage message)
    {
        if (message.ToFloat(out float value))
        {
            sensor2 = value;
        }
    }

    private void OnReceiveSensor3(OSCMessage message)
    {
        if (message.ToFloat(out float value))
        {
            sensor3 = value;
        }
    }
}
