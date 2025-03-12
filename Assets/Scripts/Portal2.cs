using UnityEngine;

// This script controls everything that happens in the second portal
public class Portal2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AkUnitySoundEngine.PostEvent("SensorPowerUp2", gameObject);
    }

}
