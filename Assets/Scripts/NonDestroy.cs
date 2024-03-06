using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonDestroy : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        GameObject[] songs = GameObject.FindGameObjectsWithTag(gameObject.tag);
        if(songs.Length >1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject); 
        }
           
    }

 
}
