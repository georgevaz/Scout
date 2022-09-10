using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Models;

public class EntityHealth : MonoBehaviour
{
    public AttributesModel attributesModel;
    [Header("UI")]
    public Slider slider;

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
    }

    public void GainHealth()
    {
        attributesModel.CurrentHealth += 5;

    }
}
