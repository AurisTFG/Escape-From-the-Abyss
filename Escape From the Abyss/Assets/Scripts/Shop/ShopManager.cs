using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager thisInstance;
    public ShopItemSO[] shopItemsSO;
    public GameObject[] shopPanelsSO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;

    private CoinsCounter _coinsInstance;

    private void Awake()
    {
        thisInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _coinsInstance = CoinsCounter.instance;

        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanelsSO[i].SetActive(true);
        }
        UpdateUI();
        LoadPanels();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        CheckPurchaserable();
    }

    public void CheckPurchaserable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (_coinsInstance.currentCoins >= shopItemsSO[i].baseCost)
            {
                myPurchaseBtns[i].interactable = true;
            }
            else
            {
                myPurchaseBtns[i].interactable = false;
            }
        }
    }

    public void PurchaseItem(int buttonNumber)
    {
        if (_coinsInstance.currentCoins >= shopItemsSO[buttonNumber].baseCost)
        {
            _coinsInstance.DecreaseCoins(shopItemsSO[buttonNumber].baseCost);
            UpdateUI();
            

            //unlock item here
        }
    }

    public void LoadPanels()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanels[i].titleText.text = shopItemsSO[i].title;
            shopPanels[i].descriptionText.text = shopItemsSO[i].description;
            shopPanels[i].costText.text = "Coins: " + shopItemsSO[i].baseCost.ToString();
        }
    }
}
