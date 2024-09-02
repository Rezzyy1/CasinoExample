using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;

    public void SettingsButtonPressed()
    {
        settingsPanel.SetActive(true);

    }

    public void ReturnButtonPressed()
    {
        settingsPanel.SetActive(false);
    }
}
