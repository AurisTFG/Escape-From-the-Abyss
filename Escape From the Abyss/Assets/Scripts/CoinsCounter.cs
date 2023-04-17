using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsCounter : MonoBehaviour, IDataPersistence
{
    public static CoinsCounter instance;
    public int currentCoins = 0;
    public TMP_Text coinDisplay;

    private void Awake()
    {
        instance = this;
    }

    public void LoadData(GameData data)
    {
        this.currentCoins = data.coinsCount;
    }

    public void SaveData(ref GameData data)
    {
        data.coinsCount = this.currentCoins;
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
