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
    int buttonsCheck = 0;
     List<int> indexList = new List<int>();

    [Header("Timer")]
    //[SerializeField] Image timerImage;
    Timer timer;

    [Header("Level")]
    [SerializeField] TextMeshProUGUI levelText;
    int phase = 0;
    int level = 1;
    //LevelKeeper level;

    void Awake()
    {
        timer = FindObjectOfType<Timer>(); 
        //level = FindObjectOfType<LevelKeeper>();
        Inicializate();    
    }

    // Update is called once per frame
    void Update(){

    }

    //¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡Revisar porque me ha salido 2 veces el numero 4!!!!!!!!!!!!!!!!!!!!!!!!!
    //----------------------------------------------------------------------------------------------------
    public void InitializeButton(int number){
        Debug.Log("Inicializo");
        for (int i = 0; i < number; i++)
        {
            int index = indexList[Random.Range(0, indexList.Count)];
            Debug.Log("Index numero: "+ index);
            buttons[index].GetComponent<ButtonsProperty>().isCorrect = true;
            indexList.Remove(index);
        }
    }
//-------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------

    public void OnButtonSelected(int index){
        bool isGreen = buttons[index].GetComponent<ButtonsProperty>().isGreen();
        if(isGreen){
            Debug.Log("isGreen");            
            ChangeButtonsColor(buttons[index]);
            buttonsCheck++;
        }else
        {
            Debug.Log("False");
        }     
    }

    public void OnButtonCheck(){
        if(buttonsCheck == numberGreenButtons){
            Debug.Log("Numeros correctos");
            NextPhase();
        }else{
            Debug.Log("No correct");
        }
    }



    private void Inicializate ()
    {
        Debug.Log("Numero de Botones verdes: "+ numberGreenButtons);
        for (int i = 0; i < buttons.Length; i++)
        {
            indexList.Add(i);
        }        
        InitializeButton(numberGreenButtons);
    }
    private void ChangeButtonsColor(GameObject button){
        button.GetComponent<Button>().interactable = false;
    }

    public void NextPhase()
    {
        Debug.Log("NextPhase");
        buttonsCheck = 0;
        phase++;        
        RefreshInteractable();
        if(phase == 5){
            NextLevel();
        }
        timer.timeValue = timer.timeToEnd;
        Inicializate();
              
    }

    public void NextLevel()
    {
        Debug.Log("NextLevel");
        level++;
        numberGreenButtons++;
        if(timer.timeToEnd > 5){
            timer.timeToEnd -= 5;
        }        
        if(numberGreenButtons == 9){
            numberGreenButtons=2;
        }     
    }

    public void RefreshInteractable()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
        }
    }


    public void GameOver()
    {

    }
}
