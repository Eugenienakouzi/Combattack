using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public CharactersStat characterStats; // R�f�rence aux statistiques du personnage
    public Image healthBarFill; // R�f�rence � l'image de la barre de vie remplie

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
        // Mettre � jour la barre de vie en continu si n�cessaire
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
