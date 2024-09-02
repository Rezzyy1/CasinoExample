using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;

    public void ShopButtonPressed()
    {
        shopPanel.SetActive(true);

    }

    public void ReturnButtonPressed()
    {
        shopPanel.SetActive(false);
    }
}

