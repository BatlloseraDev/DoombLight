using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    public GameObject slimePrefab;
    public float tiempoEntreSpawn = 2f;
    private float tiempoTranscurrido= 0f;
    public GameObject[] pointsToSpawn;
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        tiempoTranscurrido+=Time.deltaTime;

        if(tiempoTranscurrido>=tiempoEntreSpawn)
        {
           SpawnearSlime();
           tiempoTranscurrido=0f; 
        }
    }


    void SpawnearSlime()
    {
        for(int i=0; i<pointsToSpawn.Length; i++)
        {
            Instantiate(slimePrefab,pointsToSpawn[i].transform.position, Quaternion.identity);
        }
    }
}
