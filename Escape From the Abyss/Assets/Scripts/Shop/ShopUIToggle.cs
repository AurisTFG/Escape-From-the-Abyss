using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIToggle : MonoBehaviour
{
    [SerializeField] GameObject shopUI;
    [SerializeField] KeyCode[] toggleShopUIkeys;
    [SerializeField] Transform shopTransform;

    public static bool ShopIsOpened = false;
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < toggleShopUIkeys.Length; i++)
        {
            if (Input.GetKeyDown(toggleShopUIkeys[i]))
            {
                if (IsPlayerNearShop())
                {
                    ShopIsOpened = !ShopIsOpened;
                    shopUI.SetActive(!shopUI.activeSelf);
                    break;
                }
                else if (ShopIsOpened)
                {
                    ShopIsOpened = false;
                    shopUI.SetActive(false);
                }
            }
        }
    }

    private bool IsPlayerNearShop()
    {
        // Perform spatial check here
        // Example:
        float distanceThreshold = 5f;
        Vector3 playerPosition = transform.position;
        Vector3 shopPosition = shopTransform.position;
        float distance = Vector3.Distance(playerPosition, shopPosition);

        return distance <= distanceThreshold;
    }

}
