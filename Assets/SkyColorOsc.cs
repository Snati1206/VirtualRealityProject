using UnityEngine;

public class SkyColorOsc : MonoBehaviour
{
    public OSCManager oscManager;
    public Material skyMaterial;
    [SerializeField] int blue = 208;
    [SerializeField] int red = 231; 
    [SerializeField] int green = 144;
    [SerializeField] int alpha = 200;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (skyMaterial == null)    
        {
            Debug.LogError("No sky material have been asigned !");
            return;
        }
        if (oscManager == null)
        {
            Debug.LogError("No OSCManager have been asigned !");
            return;
        }
        else
        {
            skyMaterial.SetColor("_Tint", new Color((float)red/255f, (float)green/255f, (float)blue/255f, (float)alpha/255f));
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (skyMaterial != null)
        {
            SkyColorChanger(oscManager, skyMaterial, red, green, blue, alpha);
        }



    }



    void SkyColorChanger(OSCManager osc, Material material, float r, float g, float b, float a)
    {
        float newRed = r + osc.sensor1/2f; 
        float newGreen = g + osc.sensor2/2f;
        float newBlue = b + osc.sensor3/2f;
        // Change the color of the skybox
        material.SetColor("_Tint", new Color(newRed/255f, newGreen/255f, newBlue/255f, a/255f));

    }


}
