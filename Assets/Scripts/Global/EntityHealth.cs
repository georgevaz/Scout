using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Models;
using EZCameraShake;

public class EntityHealth : MonoBehaviour
{
    public AttributesModel attributesModel;
    [Header("UI References")]
    public Slider slider;
    public GameObject healthFlash;

    private void Awake()
    {
        attributesModel.CurrentHealth = attributesModel.MaxHealth;
        slider.maxValue = attributesModel.MaxHealth;
        slider.value = attributesModel.CurrentHealth;
    }
    private void Update()
    {
        CalculateHealth();
    }
    private void CalculateHealth()
    {
        if (attributesModel.CurrentHealth <= 0)
        {
            attributesModel.CurrentHealth = 0;
        }
        else if (attributesModel.CurrentHealth >= attributesModel.MaxHealth)
        {
            attributesModel.CurrentHealth = attributesModel.MaxHealth;
        }

        slider.value = attributesModel.CurrentHealth;
    }

    public void LoseHealth()
    {
        attributesModel.CurrentHealth -= 5;
        CameraShaker.Instance.ShakeOnce(2f, 3f, .1f, 1f);
        healthFlash.GetComponent<Animation>().Play("HealthFlash");
    }

    public void GainHealth()
    {
        attributesModel.CurrentHealth += 5;

    }
}
