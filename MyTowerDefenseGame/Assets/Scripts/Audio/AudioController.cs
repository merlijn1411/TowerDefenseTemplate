using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioMixer TheMixer;

    public Slider musicSlider, sfxSlider;

    void Start()
    {
        float vol = 0f;

        TheMixer.GetFloat("MusicVol", out vol);
        musicSlider.value = vol;

        TheMixer.GetFloat("SFXVol", out vol);
        sfxSlider.value = vol;
    }

    public void SetMusicVol()
    {
        TheMixer.SetFloat("MusicVol", musicSlider.value);
        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }

    public void SetSFXVol()
    {
        TheMixer.SetFloat("SFXVol", sfxSlider.value);
        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }
}
