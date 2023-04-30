using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIToggle : MonoBehaviour
{
    [SerializeField] GameObject shopUI;
    [SerializeField] KeyCode[] toggleShopUIkeys;

    public static bool ShopIsOpened = false;
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < toggleShopUIkeys.Length; i++)
        {
            if (Input.GetKeyDown(toggleShopUIkeys[i]))
            {
                ShopIsOpened = !ShopIsOpened;
                shopUI.SetActive(!shopUI.activeSelf);
                break;
            }
        }
    }
}
