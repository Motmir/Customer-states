using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class Audio_manager : MonoBehaviour
{
  
    public AudioMixer mixer;

    public void changeVolume (float sliderValue)
    {
        mixer.SetFloat("musicVolume", Mathf.Log(sliderValue)*20);
            PlayerPrefs.SetFloat("musicVolume",  sliderValue);
    }

   
}

