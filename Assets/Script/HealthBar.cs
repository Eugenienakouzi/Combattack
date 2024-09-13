using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public CharactersStat characterStats; // Référence aux statistiques du personnage
    public Image healthBarFill; // Référence à l'image de la barre de vie remplie

    void Start()
    {
        if (characterStats == null)
        {
            Debug.LogError("CharacterStats not assigned!");
        }

        // Initialiser la barre de vie
        UpdateHealthBar();
    }

    void Update()
    {
        // Mettre à jour la barre de vie en continu si nécessaire
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (characterStats != null && healthBarFill != null)
        {
            float healthPercentage = Mathf.Clamp01((float)characterStats.health / 100);
            healthBarFill.fillAmount = healthPercentage;
        }
    }
}
