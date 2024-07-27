using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class Audio_manager : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }

    public void changeVolume (float sliderValue)
    {
        mixer.SetFloat("musicVolume", Mathf.Log(sliderValue)*20);
            PlayerPrefs.SetFloat("MusicVolume",  sliderValue);
    }
}

