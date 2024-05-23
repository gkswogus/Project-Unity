using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    [TextArea]
    public string dialogue;
}
public class SecondsNpcAsk : MonoBehaviour
{

    [SerializeField] private Image DialogueBox; 
    [SerializeField] private Text txt_Dialogue; 

    private bool isDialogue = false; 
    private int count = 0; 

    [SerializeField] private Dialogue[] dialogue;

    GameObject questManager;

    bool tiponoff = true;
    private void Start()
    {
        questManager = GameObject.Find("QuestManager");

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
       
        txt_Dialogue.text = dialogue[count].dialogue;
        count++; 

    }


    
    void Update()
    {
        if (isDialogue) 
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
              
                if (count < dialogue.Length) NextDialogue(); 
                else
                {
                    ONOFF(false); 
                    if (tiponoff)
                    {
                        TollTipmanager.instance.TollTip.SetActive(true);
                        TollTipmanager.instance.TollTipTxt.text = string.Format("PŰ �� ���� ĳ���� �ɷ�ġ Ȯ�ΰ�, �����Ƽ ����Ʈ�� ���� �ɷ�ġ�� ���� ��ų�� �ֽ��ϴ�.");
                    }
                }               
            }
        }
        if (count == dialogue.Length && questManager.GetComponent<QuestManager>().currentPlayerLevel==1)
        {    
            GameEventManager.instance.playerEvents.ExperienceGained(100);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            tiponoff = false;
            TollTipmanager.instance.TollTip.SetActive(false);
        }
    }
}