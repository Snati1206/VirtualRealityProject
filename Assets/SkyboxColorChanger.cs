using UnityEngine;

public class SkyboxColorChanger : MonoBehaviour
{
    public Material skyboxMaterial; // Matériau de la Skybox
    public float interval = 20f; // Temps entre chaque changement de couleur
    private Color originalColor; // Couleur originale de la Skybox

    void Start()
    {
        if (skyboxMaterial == null)
        {
            Debug.LogError("Aucun matériau de Skybox assigné !");
            return;
        }

        // Stocke la couleur d'origine
        originalColor = skyboxMaterial.GetColor("_Tint");

        // Lance la routine pour changer la couleur
        InvokeRepeating(nameof(ChangeSkyboxColor), 0f, interval);
    }

    void ChangeSkyboxColor()
    {
        if (skyboxMaterial == null) return;

        // Génère une couleur aléatoire
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        // Applique la couleur aléatoire au Tint Color de la Skybox
        skyboxMaterial.SetColor("_Tint", randomColor);

        Debug.Log($"Nouvelle couleur : {randomColor}");
    }

    void OnDisable()
    {
        // Remet la couleur d'origine si le script est désactivé
        if (skyboxMaterial != null)
        {
            skyboxMaterial.SetColor("_Tint", originalColor);
        }
    }
}
