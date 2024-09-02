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

    private float volume = 0;

    private void Start()
    {
        // Привязка обработчика к событию onValueChanged
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        volume = PlayerPrefs.GetFloat("Volume", 1f);
        audioS.volume = volume;
        slider.value = volume;
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

    public void OnSliderValueChanged(float value)
    {
        volume = value;
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
        audioS.volume = volume;
    }

    //public void PlaySound()
    //{
    //    audioS.PlayOneShot(clip);
    //}

}