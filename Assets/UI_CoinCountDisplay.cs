using System;
using TMPro;
using UnityEngine;

public class UI_CoinCountDisplay : MonoBehaviour
{
    public coinComponent coinComponent;
    public TextMeshProUGUI textComponent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinComponent.OnCoinCountInitialised += OnCoinCountInitialised;
        coinComponent.OnCoinCount += OnCoinCount;
    }

    private void OnCoinCount(float coinCounter)
    {
        textComponent.text = coinCounter.ToString();
    }

    private void OnCoinCountInitialised(float coinCounter)
    {
        textComponent.text = coinCounter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
