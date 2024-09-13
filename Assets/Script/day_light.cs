using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Range(0, 24)]
    public float currentTime = 12f;

    public float dayDuration = 86400f; // Durée d'une journée en secondes
    public float timeScale = 1f; // Échelle du temps normal

    private float sunriseAngle = -4f;
    private float sunsetAngle = 180f;
    private float nightAngle = 221f;

    public Light sunLight;
    public float maxSunIntensity = 2.5f;
    public Color dayColor = Color.white;
    public Color nightColor = new Color(0.1f, 0.1f, 0.35f);

    private float sunriseHour = 5f;
    private float sunsetHour = 20f;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(nightAngle, 0f, 0f);
        sunLight.intensity = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Vérifier si la touche LeftAlt est enfoncée
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            timeScale = 10000f; // Accélérer le temps (ajuster cette valeur pour la vitesse souhaitée)
        }
        else
        {
            timeScale = 1f; // Vitesse normale
        }

        // Mettre à jour l'heure actuelle en fonction de la vitesse du temps
        currentTime += (24f / dayDuration) * timeScale * Time.deltaTime;

        if (currentTime >= 24f)
        {
            currentTime = 0f; // Réinitialiser après 24 heures
        }

        if (currentTime >= sunriseHour && currentTime <= sunsetHour)
        {
            float dayProgress = Mathf.InverseLerp(sunriseHour, sunsetHour, currentTime);

            float sunAngle = Mathf.Lerp(sunriseAngle, sunsetAngle, dayProgress);

            transform.rotation = Quaternion.Euler(sunAngle, 0f, 0f);

            float intensityFactor = Mathf.Sin(dayProgress * Mathf.PI);
            sunLight.intensity = Mathf.Lerp(0f, maxSunIntensity, intensityFactor);

            sunLight.color = Color.Lerp(nightColor, dayColor, intensityFactor);
        }
        else
        {
            transform.rotation = Quaternion.Euler(nightAngle, 0f, 0f);
            sunLight.intensity = 0f;
            sunLight.color = nightColor;

            if (currentTime >= sunsetHour && currentTime < 24f)
            {
                transform.rotation = Quaternion.Euler(nightAngle, 0f, 0f);
            }
            else if (currentTime >= 0f && currentTime < sunriseHour)
            {
                transform.rotation = Quaternion.Euler(nightAngle, 0f, 0f);
            }
        }
    }
}
