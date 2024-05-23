using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable] 
public class Dialogue2
{
    [TextArea]
    public string dialogue2;
}



public class FirstQuestAskStart : MonoBehaviour
{

    [SerializeField] private Image DialogueBox; 
    [SerializeField] private Text txt_Dialogue; 

    private bool isDialogue = false; 
    private int count = 0; 

    [SerializeField] private Dialogue2[] dialogue2;

    bool onoff=true;

    [Header("문 개방")]
    [SerializeField] GameObject Door;
    [SerializeField] GameObject DCameras;
    [SerializeField] GameObject MainCameras;
    private void Start()
    {
        DCameras.SetActive(false);
        MainCameras.SetActive(true);

        DialogueBox.gameObject.SetActive(false);
        txt_Dialogue.gameObject.SetActive(false);
    }

    public void ShowDialogue()
    {
        ONOFF(true);
        count = 0;
        NextDialogue(); 

     
    }

    private void ONOFF(bool _flag)
    {
        DialogueBox.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        isDialogue = _flag;
    }

    private void NextDialogue()
    {
       
        txt_Dialogue.text = dialogue2[count].dialogue2;
        count++; 
        if (count == dialogue2.Length - 1)
        {
            Door.GetComponent<CDoor>().DoorOpens = true;
            DCameras.SetActive(true);
            MainCameras.SetActive(false);
        }
    }

   
    void Update()
    {
        if (isDialogue) 
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
               
                if (count < dialogue2.Length)
                {
                    NextDialogue(); 
                }            
               else
                {
                    ONOFF(false);  
                    Door.GetComponent<CDoor>().DoorOpens = false;
                    DCameras.SetActive(false);
                    MainCameras.SetActive(true);
                    if (onoff)
                    {
                        TollTipmanager.instance.TollTip.SetActive(true);
                        TollTipmanager.instance.TollTipTxt.text = string.Format("Q키 를 통해 퀘스트 정보를 확인할 수 있습니다.");
                        SoundManager.instance.Play(UISOUND.QuestO);
                    }
                }         
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            onoff = false;
            TollTipmanager.instance.TollTip.SetActive(false);
        }
    }

}