using UnityEngine;

public class PositionTransformer : MonoBehaviour
{
    public GameObject cube;
    public OSCManager oscManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (cube == null)
        {
            Debug.LogError("No 3D object have been asigned !");
            return;
        }

        if (oscManager == null)
        {
            Debug.LogError("No OSCManager have been asigned !");
            return;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cube != null && oscManager != null)
        {
            cube.transform.rotation = Quaternion.Euler(OSCManager.sensor1, OSCManager.sensor2, OSCManager.sensor3);
        }
        
    }
}

