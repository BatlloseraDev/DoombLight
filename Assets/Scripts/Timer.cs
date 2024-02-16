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
               
                textMeshPro.text = "Timer: " + Mathf.Round(timeValue); 
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
