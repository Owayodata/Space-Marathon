using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class AudioManager : MonoBehaviour
{
    //define sliders and audiomixer objects into unity editor to access them.
    public Slider masterVol, musicVol, sfxVol;
    public AudioMixer mainAudioMixer;


    //define constant strings to use it later to save values.
    private const string MasterVolKey = "MasterVol";
    private const string MusicVolKey = "MusicVol";
    private const string SfxVolKey = "SfxVol";

    //put a float value for slider to make settings more accurate, turn value into math func and multiply it with 20 as max vol, save the settings.
    public void changeMasterVolume()
    {
        float volume = masterVol.value;
        mainAudioMixer.SetFloat("MasterVol", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(MasterVolKey, volume);
    }

    public void changeMusicVolume()
    {
        float volume = musicVol.value;
        mainAudioMixer.SetFloat("MusicVol", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(MusicVolKey, volume);
    }

    public void changeSFXVolume()
    {

        float volume = sfxVol.value;
        mainAudioMixer.SetFloat("SfxVol", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat(SfxVolKey, volume);
    }

    // Start is called before the first frame update
    void Start()
    {
        //if PlayerPrefs has ---VolKey, get float value from playerprefs and turn it into float value, change audio mixer according to value, then override it with turnin ---vol.Value into float.
        if (PlayerPrefs.HasKey(MasterVolKey))
        {
            float masterVolValue = PlayerPrefs.GetFloat(MasterVolKey);
            mainAudioMixer.SetFloat("MasterVol", masterVolValue);
            masterVol.value = masterVolValue;
        }

        if (PlayerPrefs.HasKey(MusicVolKey))
        {
            float musicVolValue = PlayerPrefs.GetFloat(MusicVolKey);
            mainAudioMixer.SetFloat("MusicVol", musicVolValue);
            musicVol.value = musicVolValue;
        }

        if (PlayerPrefs.HasKey(SfxVolKey))
        {
            float sfxVolValue = PlayerPrefs.GetFloat(SfxVolKey);
            mainAudioMixer.SetFloat("SfxVol", sfxVolValue);
            sfxVol.value = sfxVolValue;
        }
    }
}
