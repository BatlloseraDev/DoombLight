using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private SoundLoader soundLoader;

    [SerializeField]private List<AudioClip> soundsToPlay = new List<AudioClip>(); 
    [SerializeField] private AudioSource musicSource;
    private AudioSource audioSource;
    private AudioSource audioSourceSFX;
    private int currentIndex = 0;
    public AudioClip buttonSound;
    public AudioClip buttonPhaseSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(musicSource != null){
            musicSource.volume = PlayerPrefs.GetFloat("MusicVolume");
        }
        audioSourceSFX = gameObject.AddComponent<AudioSource>();
         
        soundLoader = GetComponent<SoundLoader>();
        if(PlayerPrefs.HasKey("MusicVolume")){
           SetVolumeMusic(PlayerPrefs.GetFloat("MusicVolume"));
        }
        if(PlayerPrefs.HasKey("SFXVolume")){
            SetVolumeSFX(PlayerPrefs.GetFloat("SFXVolume"));
        }
        /*AddSoundToList("Welcome");
        AddSoundToList("LevelSound");
        AddSoundToList("LevelSound_1");*/

        
    }


    private void Update()
    {
        CheckPlayList();

    }

    private void CheckPlayList()
    {
        if (!audioSource.isPlaying)
        {
            //Debug.Log("Current Index " + currentIndex + " soundsToPlay " + (soundsToPlay.Count) + " y la logica" + (currentIndex < soundsToPlay.Count));
            if (currentIndex < soundsToPlay.Count)
            {

                currentIndex++;
                PlayNextSound();
            }
            else
            {
                //currentIndex = 0;
                //soundsToPlay.Clear(); 
            }
        }
        else if (audioSource.isPlaying && currentIndex == soundsToPlay.Count)
        {
            currentIndex = 0;
            soundsToPlay.Clear();
        }
    }

    public void AddSoundToList(string soundName)
    {
        AudioClip audio= soundLoader.LoadSound(soundName);
        if(audio!=null)
        {
            soundsToPlay.Add(audio); 
        }
    }

    public void PlaySound(String soundName) //Para testear
    {
        AudioClip audio = soundLoader.LoadSound(soundName);
        if(audio != null)
        {
            AudioSource.PlayClipAtPoint(audio, transform.position); 
        }
    }
   

   void PlayNextSound()
   {
        audioSource.clip = soundsToPlay[currentIndex-1];
        audioSource.Play(); 
   }

   public void PlayButtonSound()
   {
        AudioSource.PlayClipAtPoint(buttonSound, transform.position, audioSourceSFX.volume); 
   }

   public void PlayButtonNextPhaseSound()
   {
         AudioSource.PlayClipAtPoint(buttonPhaseSound, transform.position,audioSourceSFX.volume); 
   }

   public void SetVolumeMusic(float volume)
   {
         audioSource.volume = volume;
         //musicSource.volume = volume;
         Debug.Log("El volumen es: "+ audioSource.volume);
   }

   public void SetVolumeSFX(float volume)
   {
         audioSourceSFX.volume = volume;
         Debug.Log("El volumen es: "+ audioSourceSFX.volume);
   }
}
