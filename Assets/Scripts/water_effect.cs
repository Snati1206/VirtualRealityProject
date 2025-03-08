using System.Collections;
using UnityEngine;

public class WaterColorChanger : MonoBehaviour
{
    [Header("Matériau de l'eau")]
    public Material waterMaterial; // Matériau de l'eau à modifier

    [Header("Couleurs")]
    public Color deepColor = new Color(0.09f, 0.56f, 0.72f); // Couleur initiale
    public Color alternateColor = Color.red; // Couleur temporaire

    [Header("Durées")]
    public float changeInterval = 20f; // Temps avant changement
    public float changeDuration = 5f; // Durée du changement

    private bool isChanging = false;
    private float timer = 0f;
    private string colorProperty = "_DeepColor"; // Nom du paramètre dans le shader

    void Start()
    {
        if (waterMaterial != null)
        {
            Debug.Log("✅ Matériau assigné : " + waterMaterial.name);

            // Vérification du Shader et affichage de la couleur actuelle
            if (waterMaterial.HasProperty(colorProperty))
            {
                waterMaterial.SetColor(colorProperty, deepColor);
                Debug.Log("🎨 Couleur initiale appliquée : " + deepColor);
            }
            else
            {
                Debug.LogError("❌ Le matériau ne possède pas la propriété " + colorProperty + ". Vérifie le nom exact dans Shader Graph !");
            }
        }
        else
        {
            Debug.LogError("❌ Aucun matériau assigné ! Drag & Drop ton matériau dans l'Inspector.");
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (!isChanging && timer >= changeInterval)
        {
            StartCoroutine(ChangeWaterColor());
        }
    }

    IEnumerator ChangeWaterColor()
    {
        isChanging = true;
        float elapsedTime = 0f;

        Color startColor = waterMaterial.GetColor(colorProperty);
        Color targetColor = (startColor == deepColor) ? alternateColor : deepColor;

        Debug.Log("🔄 Début du changement de couleur...");

        while (elapsedTime < changeDuration)
        {
            elapsedTime += Time.deltaTime;
            waterMaterial.SetColor(colorProperty, Color.Lerp(startColor, targetColor, elapsedTime / changeDuration));
            yield return null;
        }

        Debug.Log("✅ Changement terminé ! Nouvelle couleur : " + targetColor);

        waterMaterial.SetColor(colorProperty, targetColor);
        timer = 0f;
        isChanging = false;
    }
}
