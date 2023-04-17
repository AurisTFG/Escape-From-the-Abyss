using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsCounter : MonoBehaviour
{
    public static CoinsCounter instance;
    public int currentCoins = 0;
    public TMP_Text coinDisplay;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        coinDisplay.text = currentCoins.ToString();
    }

    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        UpdateUI();
    }

    public void DecreaseCoins(int v)
    {
        currentCoins -= v;
        UpdateUI();
    }
}
