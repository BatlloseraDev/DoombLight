using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [Header("ButtonGroup")]
    [SerializeField] GameObject[] buttons;
    int numberGreenButtons = 2;
     List<int> indexList = new List<int>();

    /*[Header("Timer")]
    [SerializeField] Image timerImage;
    //Timer timer;*/

    [Header("Level")]
    [SerializeField] TextMeshProUGUI levelText;
    //LevelKeeper level;

    void Awake()
    {
        //timer = FindObjectOfType<Timer>(); 
        //level = FindObjectOfType<LevelKeeper>();
        Inicializate();
      
    }

    // Update is called once per frame
    void Update(){

    }

    public void initializeButton(int number){
        Debug.Log("Inicializo");
        for (int i = 0; i < number; i++)
        {
            int index = indexList[Random.Range(0, indexList.Count)];
            Debug.Log("Index numero: "+ index);
            buttons[index].GetComponent<ButtonsProperty>().isCorrect = true;
            indexList.Remove(index);
        }
    }


    public void OnButtonSelected(int index){
        bool isGreen = buttons[index].GetComponent<ButtonsProperty>().isGreen();
        if(isGreen){
            Debug.Log("isGreen");
            //Reiniciar nivel
        }else
        {
            Debug.Log("False");
        }
     
    }



    private void Inicializate ()
    {
        Debug.Log("Numero de Botones verdes: "+ numberGreenButtons);
        for (int i = 0; i < buttons.Length; i++)
        {
            indexList.Add(i);
        }        
        initializeButton(numberGreenButtons);
    }
    private void changeButtonsColor(){

    }
}
