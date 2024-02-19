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
    [SerializeField]List<int> indexList = new List<int>();

    [Header("Timer")]
    //[SerializeField] Image timerImage;
    Timer timer;

    [Header("Level")]
    [SerializeField] TextMeshProUGUI levelText;
    int phase = 0;
    int level = 1;

    [Header("Imagenes")]
    [SerializeField] Sprite buttonUnpress;
    [SerializeField] Sprite buttonPress;

    [Header("Colores")]
    private Color colorGreen= new Color (0.25f,1f,0.3317f);
    private Color colorBase = Color.white; 

    bool inicializarLista= false; 
  
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

    public void InitializeButton(int number){
        Debug.Log("Inicializo");
        for (int i = 0; i < number; i++)
        {
            int index = indexList[Random.Range(0, indexList.Count)];
            Debug.Log("Index numero: "+ index + " en fase: " + phase + " y nivel :" + level);
            buttons[index].GetComponent<ButtonsProperty>().isCorrect = true;
            buttons[index].GetComponent<Image>().color = colorGreen; 
            indexList.Remove(index);
        }
    }

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
        Debug.Log("Numero de Botones verdes: " + numberGreenButtons);
        LoadList();
        InitializeButton(numberGreenButtons);
    }

    private void LoadList()
    {
        if(!inicializarLista)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                indexList.Add(i);
            }
            inicializarLista = true;
        }
        else
        {
            indexList.Clear();
            for (int i = 0; i < buttons.Length; i++)
            {
                indexList.Add(i);
            }

        }
        
    }

    private void ChangeButtonsColor(GameObject button){
        button.GetComponent<Button>().interactable = false;
        button.GetComponent<Image>().sprite = buttonPress; 
    }

    public void NextPhase()
    {
        Debug.Log("NextPhase");
        buttonsCheck = 0;
        phase++;        
        RefreshInteractable();
        if(phase == 5){
            NextLevel();
            phase= 0; 
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
        if(level >= 9){
            numberGreenButtons=Random.Range((int)0,(int)10); //yo creo que asi queda mas divertido
        }     
    }

    public void RefreshInteractable()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
            buttons[i].GetComponent<Image>().sprite = buttonUnpress; 
            buttons[i].GetComponent<Image>().color = colorBase; 
        }
    }


    public void GameOver()
    {
        //yo diria de poner un canvas con que has perdido, dos botones uno de resetear y otro al menu principal.
    }
}
