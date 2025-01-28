using UnityEngine;

public class SkyboxColorInfluence : MonoBehaviour
{
    [SerializeField] private Material skyboxMaterial; // Ton matériau de skybox
    [SerializeField] private Light directionalLight;  // Ta lumière principale
    [SerializeField] private float intensityFactor = 1.0f; // Facteur d'intensité pour ajuster l'influence

    private void Update()
    {
        if (skyboxMaterial != null && skyboxMaterial.HasProperty("_MainTex"))
        {
            Texture2D skyboxTexture = skyboxMaterial.GetTexture("_MainTex") as Texture2D;

            if (skyboxTexture != null)
            {
                // Obtenir la couleur moyenne de la texture
                Color averageColor = GetAverageColor(skyboxTexture);

                // Ajuster la couleur de la lumière directionnelle en fonction
                directionalLight.color = averageColor * intensityFactor;
            }
        }
    }

    private Color GetAverageColor(Texture2D texture)
    {
        // Lire toutes les couleurs de la texture (attention à la performance si la texture est très grande)
        Color[] pixels = texture.GetPixels();
        Color averageColor = Color.black;

        foreach (Color pixel in pixels)
        {
            averageColor += pixel;
        }

        // Moyenne
        averageColor /= pixels.Length;
        return averageColor;
    }
}
