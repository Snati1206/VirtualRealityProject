using UnityEngine;

public class LightsController : MonoBehaviour
{

    public Light mainLight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (mainLight == null)
        {
            Debug.LogError("Light is not assigned");
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method that matches the skybox color with the light color
    void MatchSkybox()
    {
        
    }

}
