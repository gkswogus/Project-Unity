using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestUiOnOff : MonoBehaviour
{
 
    public GameObject QuestMap;
    bool ONOFF = false;
   
    public Button StartButton;
    public Button FinishButton;
    public bool isChoose = false; //스타트버튼 불값
    public bool isChoose1 = false; //피니쉬버튼 불값

    [Header("퀘스트창 카메라 관리")]
    [SerializeField]private GameObject Cameras;
    bool CONOFF = true;
    private void Awake()
    {
        QuestMap.SetActive(ONOFF);
    }
    private void Start()
    {
        Cameras.SetActive(CONOFF);
    }
    private void OnEnable()
    {
        GameEventManager.instance.inputEvents.OnQuestWindowOn_Off += QuestWindowOn_Off;
    }

    private void OnDisable()
    {      
       GameEventManager.instance.inputEvents.OnQuestWindowOn_Off -= QuestWindowOn_Off;
    }
    public void ChangeColor() //시작버튼 호출
    {
        SoundManager.instance.Play(UISOUND.QuestPageClick);

        ColorBlock colorBlock = StartButton.colors;
        isChoose = !isChoose;
        colorBlock.normalColor = isChoose ? new Color(0, 1f, 0, 1f) : Color.white;
        colorBlock.selectedColor = isChoose ? new Color(0, 1f, 0, 1f) : Color.white;
        StartButton.colors = colorBlock;

        if (isChoose1==true)
        {
            ColorBlock colorBlock1 = FinishButton.colors;
            isChoose1 = !isChoose1;
            colorBlock1.normalColor = isChoose1 ? new Color(0, 1f, 0, 1f) : Color.white;
            colorBlock1.selectedColor = isChoose1 ? new Color(0, 1f, 0, 1f) : Color.white;
            FinishButton.colors = colorBlock1;
            isChoose1 = false;               
        }
        
    }
    public void ChangeColor1() //완료버튼 호출
    {
        SoundManager.instance.Play(UISOUND.QuestPageClick);

        ColorBlock colorBlock1 = FinishButton.colors;
        isChoose1 = !isChoose1;
        colorBlock1.normalColor = isChoose1 ? new Color(0, 1f, 0, 1f) : Color.white;
        colorBlock1.selectedColor = isChoose1 ? new Color(0, 1f, 0, 1f) : Color.white;
        FinishButton.colors = colorBlock1;
        if (isChoose  == true)
        {
            ColorBlock colorBlock = StartButton.colors;
            isChoose = !isChoose;
            colorBlock.normalColor = isChoose ? new Color(0, 1f, 0, 1f) : Color.white;
            colorBlock.selectedColor = isChoose ? new Color(0, 1f, 0, 1f) : Color.white;
            StartButton.colors = colorBlock;
            isChoose = false;
        }
    }
   
    
    private void QuestWindowOn_Off()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            UIEventControll.instance.isOnUI = UIEventControll.instance.isOnUI ? false : true;
            SoundManager.instance.Play(UISOUND.QuestPage);
        }
       
    
        QuestMap.gameObject.SetActive((ONOFF) ? false : true);
        ONOFF = ONOFF ? false : true;

        Cameras.SetActive((CONOFF)?false:true);
        CONOFF = CONOFF ? false : true;
    }
   
   

}
