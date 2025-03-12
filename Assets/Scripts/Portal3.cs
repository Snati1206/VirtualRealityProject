using UnityEngine;

// This script controls everything that happens in the third portal
public class Portal3 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AkUnitySoundEngine.PostEvent("SensorPowerUp3", gameObject);
    }

}
