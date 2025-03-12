using UnityEngine;

// This script controls everything that happens in the first portal
public class Portal1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AkUnitySoundEngine.PostEvent("SensorPowerUp1", gameObject);        
    }

}
