using System;
using UnityEngine;

public class LightsControllerYellow : MonoBehaviour
{

    public Light mainLight;
    public float oscillation = 2.50f;
    public float luminosity = 12f;
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
        luminosityOscillation(oscillation);
        
    }

    // Method that matches the skybox color with the light color
    void luminosityOscillation(float oscillation)
    {
        float sin = (oscillation * Time.time)%360;
        mainLight.intensity = luminosity*Mathf.Sin(sin);
        
    }

}
