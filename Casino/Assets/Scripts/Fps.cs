using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fps : MonoBehaviour
{
    [Header("Fps")]
    [SerializeField] private int frameRate = 60;

    private void Start()
    {
        Application.targetFrameRate = frameRate;
    }
}
