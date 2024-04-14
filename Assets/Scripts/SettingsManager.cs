using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UIElements.Experimental;

public class SettingsManager : MonoBehaviour
{
    public TMP_Dropdown graphicsDropdown;
    public AudioSource music;
    public Slider volume;
    public AudioMixer volumeMixer;
    float tmp;

    public void ChangeGraphicQuality() {
        // Set choosed graphics quality
        QualitySettings.SetQualityLevel(graphicsDropdown.value);
    } 

    public void ChangeVolume() {
        // Setting volume level (change from 0-1 to dB)
        volumeMixer.SetFloat("Volume", Mathf.Log10(volume.value)*20);
    }


    void Start()
    {
        music.Play();
        graphicsDropdown.value = QualitySettings.GetQualityLevel();
        // Get volume level in dB
        volumeMixer.GetFloat("Volume", out tmp);
        // Change dB to 0-1
        volume.value = Mathf.Pow(10, (tmp/20));
    }

}
