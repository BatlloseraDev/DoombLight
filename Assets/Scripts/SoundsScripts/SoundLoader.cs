using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLoader : MonoBehaviour
{
    public AudioClip LoadSound(String soundName)
    {
        AudioClip sound =  Resources.Load<AudioClip>("Sounds/" + soundName);
        if(sound == null)
        {
            Debug.LogError("No se pudo encontrar el archivo de sonido: " +soundName);
        }
        
        return sound;
    }
}
