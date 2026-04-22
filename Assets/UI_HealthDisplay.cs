using System;
using TMPro;
using UnityEngine;

public class UI_HealthDisplay : MonoBehaviour
{
    public HealthComponent healthComponent;
    public TextMeshProUGUI textComponent
        ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        healthComponent.OnHealthChanged += OnHealthChanged;
        healthComponent.OnHealthInitialised += OnHealthInitialized;
    }

    private void OnHealthInitialized(float newHealth)
    {
       textComponent.text = newHealth.ToString();
    }

    private void OnHealthChanged(float newHealth, float amountChanged)
    {
        //Debug.Log(newHealth + ":" + amountChanged);
        //throw new NotImplementedException();
        textComponent.text = newHealth.ToString();
    }
}
