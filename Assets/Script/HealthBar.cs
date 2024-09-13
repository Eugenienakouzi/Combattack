using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public CharactersStat characterStats; 
    public Image healthBarFill; 

    void Start()
    {
        if (characterStats == null)
        {
            Debug.LogError("CharacterStats not assigned!");
        }

        UpdateHealthBar();
    }

    void Update()
    {
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
