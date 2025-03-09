using UnityEngine;

public class SkyColorOsc : MonoBehaviour
{

    public Material skyMaterial;
    public Light mainLight;
    [SerializeField] int blue = 208;
    [SerializeField] int red = 231; 
    [SerializeField] int green = 144;
    [SerializeField] int alpha = 200;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (skyMaterial == null && mainLight == null)    
        {
            Debug.LogError("Assign the lights and the skybox !");
            return;
        }
        else
        {
            skyMaterial.SetColor("_Tint", new Color((float)red/255f, (float)green/255f, (float)blue/255f, (float)alpha/255f));
            mainLight.color = new Color((float)red/255f, (float)green/255f, (float)blue/255f, (float)alpha/255f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (skyMaterial != null)
        {
            SkyColorChanger( skyMaterial, red, green, blue, alpha);
        }



    }



    void SkyColorChanger( Material material, float r, float g, float b, float a)
    {
        float newRed = r + OSCManager.sensor1/2f; 
        float newGreen = g + OSCManager.sensor2/2f;
        float newBlue = b + OSCManager.sensor3/2f;
        // Change the color of the skybox
        material.SetColor("_Tint", new Color(newRed/255f, newGreen/255f, newBlue/255f, a/255f));
        mainLight.color = new Color(newRed/255f, newGreen/255f, newBlue/255f, a/255f);

    }


}
