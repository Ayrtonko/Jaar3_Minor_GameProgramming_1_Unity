using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerScript : MonoBehaviour
{
    public Slider slider;
    public AudioMixer myMixer;
    public string mixerGroupName;

    public static float SfxValue;
    public static float MusicValue;

    private void Start()
    {
        if (mixerGroupName == "Music")
        {
            Debug.Log("music value set to: " + MusicValue);
            slider.value = AudioValues.musicValue;
        }

        if (mixerGroupName == "Sfx")
        {
            slider.value = AudioValues.sfxValue;
        }
    }

    void Update()
    {
        ChangeVolume();
    }

    void ChangeVolume()
    {
        if (slider != null)
        {
            if (mixerGroupName == "Music")
            {
                myMixer.SetFloat(mixerGroupName, slider.value);
                AudioValues.musicValue = slider.value;
            }
            if (mixerGroupName == "Sfx")
            {
                myMixer.SetFloat(mixerGroupName, slider.value);
                AudioValues.sfxValue = slider.value;
            }
            
        }
    }
}
