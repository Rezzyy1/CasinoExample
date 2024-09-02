using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLevel : MonoBehaviour
{
    [SerializeField] private GameObject ChooseGame;

    public void PlayButtonPressed()
    {
        ChooseGame.SetActive(true);

    }

    public void ReturnButtonPressed()
    {
        ChooseGame.SetActive(false);
    }
}
