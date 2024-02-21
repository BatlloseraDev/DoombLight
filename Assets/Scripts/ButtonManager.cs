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
    [SerializeField]Timer timer;

    [Header("Level")]
    [SerializeField] TextMeshProUGUI levelText;
    int phase = 0;
    int level = 1;

    [Header("Pantallas")]
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject gameScreen;
    [SerializeField] GameObject menuScreen;

    [Header("Imagenes")]
    [SerializeField] Sprite buttonUnpress;
    [SerializeField] Sprite buttonPress;

    [Header("Colores")]
    private Color colorGreen= new Color (0.25f,1f,0.3317f);
    private Color colorBase = Color.white; 

    bool inicializarLista= false; 
    SoundManager soundManager;
  
    //LevelKeeper level;

    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        soundManager =  FindObjectOfType<SoundManager>();  
        //level = FindObjectOfType<LevelKeeper>();
        //gameOverScreen = FindObjectOfType<GameOver>();
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
            GameOver();
        }     
    }

    public void OnButtonCheck(){
        if(buttonsCheck == numberGreenButtons){
            Debug.Log("Numeros correctos");
            NextPhase();
        }else{
            Debug.Log("No correct");
            GameOver();
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
        NextLevelSound();
        if(timer.timeToEnd > 5){
            timer.timeToEnd -= 5;
        }        
        if(level >= 9){
            numberGreenButtons=Random.Range((int)1,(int)10); //yo creo que asi queda mas divertido
        }     
    }

    public void NextLevelSound() //terminar de programar 
    {
        int decenas;
        int unidades;
        if(level<16)
        {
            soundManager.AddSoundToList("LevelSound_"+level);
        }
        else if(level>=16)
        {
            unidades= level%10;
            decenas= level-unidades;
            Debug.Log($"Unidades {unidades} y decenas {decenas}");
            soundManager.AddSoundToList("LevelSound_"+decenas);
            soundManager.AddSoundToList("LevelSound_"+unidades); 
        }
    }

    public void NextLevelSound2()
    {
        List<int> numbersToSound = new List<int>();
        int loop = 1;
        int number;
        if(level<16)
        {
            soundManager.AddSoundToList("LevelSound_"+level);
        }
        else if(level>=16)
        {
            do{
                if(loop != 2 ){
                    numbersToSound.Add(level%10);
                }else{
                    numbersToSound.Add(level%10 *10);
                }                
                number= level/10;
                loop++;
            }while(number >=0);
            for (int i = (numbersToSound.Count-1) ; i <= 0; i--)
            {
                switch (loop)
                {
                    case 0:numbersToSound.Add(level%10);break;
                    case 1:numbersToSound.Add(level%10 *10);break;
                    case 2: soundManager.AddSoundToList("LevelSound_"+numbersToSound[i]);
                            soundManager.AddSoundToList("LevelSound_Hundred");
                            break;
                    case 3: soundManager.AddSoundToList("LevelSound_"+numbersToSound[i]);
                            soundManager.AddSoundToList("LevelSound_Thousand");
                            break;
                }                
            }            
        }
    }

    public void RefreshInteractable()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
            buttons[i].GetComponent<Image>().sprite = buttonUnpress; 
            buttons[i].GetComponent<Image>().color = colorBase;
            buttons[i].GetComponent<ButtonsProperty>().isCorrect = false;
        }
    }

    public void Restart()
    {
        numberGreenButtons = 2;
        buttonsCheck = 0;
        phase = 0;
        level = 1;

        timer.StartAgain();        
        RefreshInteractable();
        Inicializate();

        gameScreen.SetActive(true);
        gameOverScreen.SetActive(false);
    }

    public void MainMenu()
    {
        menuScreen.SetActive(true);
        gameScreen.SetActive(false);
        gameOverScreen.SetActive(false);
    }


    public void GameOver()
    {
        //yo diria de poner un canvas con que has perdido, dos botones uno de resetear y otro al menu principal.
        gameScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }
}
