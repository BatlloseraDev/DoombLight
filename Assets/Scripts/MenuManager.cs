using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{     
    [Header("Menu")]
    SoundManager soundManager;
    [SerializeField] private TextMeshProUGUI textMaxLevel;
    [SerializeField] private GameObject secretButton;

    [Header("Pantallas")]
    [SerializeField] GameObject menuScreen;
    [SerializeField] GameObject volumeScreen;

    void Awake()
    {  
        soundManager =  FindObjectOfType<SoundManager>();
    }

    void Start()
    {  
        soundManager.AddSoundToList("Welcome");
        if(PlayerPrefs.HasKey("MaxLevel")){
            textMaxLevel.text = "Max Level: " +PlayerPrefs.GetInt("MaxLevel").ToString();
            if(PlayerPrefs.GetInt("MaxLevel")>100)
            {
                secretButton.SetActive(true); 
            }
        } 
    }  

    public void OnButtonSelected(string nameButton){
        if(nameButton.Equals("Start")){
            SceneManager.LoadScene(1);
            Destroy(gameObject);
        }else{
            menuScreen.SetActive(false);
            volumeScreen.SetActive(true);
            Debug.Log("Opciones");
        }     
    }
}
