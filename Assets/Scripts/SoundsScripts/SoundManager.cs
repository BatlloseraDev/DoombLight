using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private SoundLoader soundLoader;

    [SerializeField]private List<AudioClip> soundsToPlay = new List<AudioClip>(); 
    private AudioSource audioSource;
    private int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
        soundLoader = GetComponent<SoundLoader>();
        AddSoundToList("Welcome");
        AddSoundToList("LevelSound");
        AddSoundToList("LevelSound_1");

        
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
}
