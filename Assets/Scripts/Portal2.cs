using UnityEngine;

// This script controls everything that happens in the second portal
public class Portal2 : MonoBehaviour
{
    public GameObject player;
    public GameObject portal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AkUnitySoundEngine.PostEvent("SensorPowerUp2", gameObject);
        if (!player && !portal)
        {
        portal.transform.LookAt(player.transform);
        }
        else
        {
            Debug.LogError("Player or portal not assigned");
        }
    }

}
