using UnityEngine;

public class SkyboxColorAndExposureChanger : MonoBehaviour
{
    public Material skyboxMaterial; // Matériau de la skybox
    public float colorChangeSpeed = 0.2f; // Vitesse de transition des couleurs
    public float exposureChangeSpeed = 0.1f; // Vitesse de transition pour l'exposition
    public float minExposure = 0.8f; // Valeur minimale d'exposition
    public float maxExposure = 1.5f; // Valeur maximale d'exposition

    private Color targetColor; // Couleur cible pour le Tint Color
    private float targetExposure; // Exposition cible
    private Color initialColor; // Couleur initiale du Tint Color
    private float initialExposure; // Exposition initiale

    void Start()
    {
        // Vérifie si le matériau de Skybox est assigné
        if (skyboxMaterial == null)
        {
            Debug.LogError("Le matériau de la Skybox n'est pas assigné !");
            return;
        }

        // Initialise les valeurs initiales
        initialColor = skyboxMaterial.GetColor("_Tint"); // Récupère la couleur actuelle
        initialExposure = skyboxMaterial.GetFloat("_Exposure"); // Récupère l'exposition actuelle
        targetColor = initialColor;
        targetExposure = initialExposure;

        // Lance les changements en boucle
        InvokeRepeating(nameof(ChangeTargetValues), 0f, 20f); // Changement toutes les 20 secondes
    }

    void Update()
    {
        // Transition douce vers la nouvelle couleur
        Color currentColor = skyboxMaterial.GetColor("_Tint");
        skyboxMaterial.SetColor("_Tint", Color.Lerp(currentColor, targetColor, Time.deltaTime * colorChangeSpeed));

        // Transition douce pour l'exposition
        float currentExposure = skyboxMaterial.GetFloat("_Exposure");
        skyboxMaterial.SetFloat("_Exposure", Mathf.Lerp(currentExposure, targetExposure, Time.deltaTime * exposureChangeSpeed));
    }

    void ChangeTargetValues()
    {
        // Génère une nouvelle couleur cible aléatoire
        targetColor = new Color(
            Random.Range(0.5f, 1f), // Composante rouge (douce)
            Random.Range(0.5f, 1f), // Composante verte (douce)
            Random.Range(0.5f, 1f)  // Composante bleue (douce)
        );

        // Génère une nouvelle valeur d'exposition cible
        targetExposure = Random.Range(minExposure, maxExposure);

        Debug.Log($"Nouvelle couleur cible : {targetColor}, Nouvelle exposition cible : {targetExposure}");
    }
}
