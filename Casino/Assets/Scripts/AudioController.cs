using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private Sprite audioOn;
    [SerializeField] private Sprite audioOff;
    [SerializeField] private GameObject audioButton;

    [SerializeField] private Slider slider;

    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource audioS;

    private void Update()
    {
        audioS.volume = slider.value;
    }

    public void OnOffAudio()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            audioButton.GetComponent<Image>().sprite = audioOff;
        }
        else
        {
            AudioListener.volume = 1;
            audioButton.GetComponent<Image>().sprite = audioOn;
        }
    }

    //public void PlaySound()
    //{
    //    audioS.PlayOneShot(clip);
    //}

}