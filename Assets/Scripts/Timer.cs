using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    
    [SerializeField] float timeToEnd = 10f;

    public bool loadNextPhase;
    public float fillFraction;

    public bool isPlaying;
    float timeValue;


    void Start(){
        timeValue = timeToEnd;
        isPlaying = true;
    }

    void Update()
    {
        UpdateTimer();        
    }

    public void CancellTimmer(){
        timeValue= 0;
    }

    void UpdateTimer(){
        if(isPlaying){
            timeValue-= Time.deltaTime;
            if(timeValue > 0 ){
                fillFraction = timeValue / timeToEnd;
            }else{
                isPlaying = false;
                EndGame();
            }            
        }
        
    }

    public void EndGame(){        
        timeValue = timeToEnd;
        ButtonManager buttons = FindObjectOfType<ButtonManager>();
        buttons.GameOver();
    }

    public void StartAgain(){
        isPlaying = true;
    }

}
