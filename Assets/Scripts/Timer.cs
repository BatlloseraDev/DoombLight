using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    
    [SerializeField]public  float timeToEnd = 30f;

    public bool loadNextPhase;
  

    public bool isPlaying;
    public float timeValue;
    [SerializeField] private TextMeshProUGUI textMeshPro;


    void Start(){
        InitializeTimer();
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
               
                textMeshPro.text = "Timer: " + Mathf.Round(timeValue); 
            }else{
                isPlaying = false;
                EndGame();
            }            
        }
        
    }

    public void EndGame(){     
        timeToEnd = 30f;   
        timeValue = timeToEnd;
        isPlaying = false;
        ButtonManager buttons = FindObjectOfType<ButtonManager>();
        buttons.GameOver();
    }

    public void StartAgain(){
        InitializeTimer();
    }

    public void InitializeTimer(){
        timeToEnd = 30f;   
        timeValue = timeToEnd;
        isPlaying = true;
    }

}
