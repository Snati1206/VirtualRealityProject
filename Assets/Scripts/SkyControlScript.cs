using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;


public class SkyControlScript : MonoBehaviour
{

    public OSCManager oscManager;
    public Material skyMaterial;
    [SerializeField] float skySpeed = 0.1f;

    [SerializeField] float skyLuminosity = 1.2f;
    [SerializeField] float oscillateIntensity = 0.60f;
    [SerializeField] float freqOscillation = 0.8f;

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

 
    }

    // Update is called once per frame
    void Update()
    {
        if (skyMaterial != null )
        {
            SkyRotator(skyMaterial, skySpeed);
            SkyLuminosity(skyMaterial, skyLuminosity);
        }
        
    }
    private void SkyRotator(Material material, float speed)
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
//        Debug.Log(oscLuminosity);
    }
}


