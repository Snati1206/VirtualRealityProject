using UnityEngine;

public class WaterColorChanger : MonoBehaviour
{
    public Material waterMaterial; // Le matériau de ton Waterblock
    public Color deepColor = new Color(22f / 255f, 20f / 255f, 72f / 255f); // Couleur bleue 161448
    public Color alternateColor = Color.red; // La couleur temporaire (modifie selon tes besoins)
    public float changeInterval = 20f; // Temps avant le changement (20s)
    public float changeDuration = 5f; // Durée du changement (5s)

    private bool isChanging = false;
    private float timer = 0f;

    void Start()
    {
        // Définit la couleur initiale au lancement
        if (waterMaterial != null)
        {
            waterMaterial.SetColor("_DeepColor", deepColor);
        }
    }

    void Update()
    {
        // Compte le temps écoulé
        timer += Time.deltaTime;

        if (!isChanging && timer >= changeInterval)
        {
            // Déclenche le changement de couleur
            StartCoroutine(ChangeColor());
            timer = 0f; // Réinitialise le timer
        }
    }

    private System.Collections.IEnumerator ChangeColor()
    {
        isChanging = true;

        // Change la couleur en couleur temporaire
        if (waterMaterial != null)
        {
            waterMaterial.SetColor("_DeepColor", alternateColor);
        }

        // Attend la durée du changement
        yield return new WaitForSeconds(changeDuration);

        // Restaure la couleur initiale
        if (waterMaterial != null)
        {
            waterMaterial.SetColor("_DeepColor", deepColor);
        }

        isChanging = false;
    }
}
