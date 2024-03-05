using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VolumeControler : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sFXSlider;
    //[SerializeField] AudioSource sFXSources;

    void Start()
    {
        if(PlayerPrefs.HasKey("MusicVolume")){
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }
        if(PlayerPrefs.HasKey("SFXVolume")){
            sFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        }
    }

    public void SetMusicVolume(){
        Debug.Log("Guardo Musica "+ musicSlider.value);
        PlayerPrefs.SetFloat("MusicVolume",musicSlider.value);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(){
        Debug.Log("Guardo SFX: "+ sFXSlider.value);
        PlayerPrefs.SetFloat("SFXVolume",sFXSlider.value);
        PlayerPrefs.Save();
    }
}
