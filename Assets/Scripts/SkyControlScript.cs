using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;


public class SkyControlScript : MonoBehaviour
{

    public OSCManager oscManager;
    public Material skyMaterial;
    public Light mainLight;
    [SerializeField] float skySpeed = 0.1f;

    [SerializeField] float skyLuminosity = 0.2f;
    [SerializeField] float oscillateIntensity = 0.3f;
    [SerializeField] float freqOscillation = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (skyMaterial == null)
        {
            Debug.LogError("No sky material have been asigned !");
        
        }
        if (oscManager == null)
        {
            Debug.LogError("No OSCManager have been asigned !");
        }
        if (mainLight == null)
        {
            Debug.LogError("No main light have been asigned !");
        }

 
    }

    // Update is called once per frame
    void Update()
    {
        if (skyMaterial != null && mainLight != null)
        {
            if (EventCoroutine.alarm == true)
            {
                SkySpeed( Mathf.Lerp(skySpeed, 0.5f, Time.deltaTime*0.005f));
                skyLuminosity = Mathf.Lerp(skyLuminosity, 15f, Time.deltaTime*0.0004f);
            }
            else
            {
                SkySpeed(Mathf.Lerp(skySpeed, 0.2f, Time.deltaTime*3f));
                skyLuminosity = Mathf.Lerp(skyLuminosity, 0.2f, Time.deltaTime);
            }
            SkyRotator(skyMaterial, skySpeed, mainLight);
            SkyLuminosity(skyMaterial, skyLuminosity);
        }
        
    }

    // Rotates the skybox and assigns the rotation to the main world light
    private void SkyRotator(Material material, float speed, Light lightWorld)
    {
        // Rotate the skybox
        float rotation = (Time.time * speed) % 360;
        material.SetFloat("_Rotation", rotation);
        
    }

    private void SkyLuminosity(Material material, float luminosity)
    {
        // Change the luminosity of the skybox
        float freq = freqOscillation * Time.time;
        float oscLuminosity = luminosity + Mathf.Sin(freq%360) * oscillateIntensity;
        material.SetFloat("_Exposure", oscLuminosity);
        mainLight.intensity = oscLuminosity/5;
//        Debug.Log(oscLuminosity);
    }

    public float SkySpeed(float speed)
    {
        skySpeed = speed;
        return speed;
    }
}


