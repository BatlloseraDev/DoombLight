using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsProperty : MonoBehaviour
{
    [Header("Button Image")]
    [SerializeField] Sprite GreenButton;
    [SerializeField] Sprite defaultButton;

    [Header("Button Atributte")]
    [SerializeField]public  bool isCorrect;

    public bool isGreen(){
        return isCorrect;
    }

}
