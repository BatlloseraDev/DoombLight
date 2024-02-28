using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{     
    SoundManager soundManager;
    [SerializeField] private TextMeshProUGUI textMaxLevel;

    void Awake()
    {  
        soundManager =  FindObjectOfType<SoundManager>();
    }

    void Start()
    {  
        soundManager.AddSoundToList("Welcome");
        if(PlayerPrefs.HasKey("MaxLevel")){
            textMaxLevel.text = PlayerPrefs.GetInt("MaxLevel").ToString();
        } 
    }  

    public void OnButtonSelected(string nameButton){
        if(nameButton.Equals("Start")){
            SceneManager.LoadScene(1);
            Destroy(gameObject);
        }else{
            Debug.Log("Opciones");
        }     
    }
}
