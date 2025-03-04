using UnityEngine;
using extOSC;

public class OSCManager : MonoBehaviour

{
    public string networkIP = "127.0.0.1";
    public int port = 8000;

    private OSCReceiver receiver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        receiver = gameObject.AddComponent<OSCReceiver>();
        receiver.LocalHost = networkIP;
        receiver.LocalPort = port;
        receiver.Bind("/sensor1", TestMethod);
        receiver.Bind("/sensor2", TestMethod);
        receiver.Bind("/sensor3", TestMethod);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TestMethod(OSCMessage message)
    {
        Debug.Log(message);
    }
}
