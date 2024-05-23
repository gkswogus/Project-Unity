using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]  
public class Dialogue3
{
    [TextArea]
    public string dialogue3;
}



public class FirstQuestAskFinish : MonoBehaviour
{

    [SerializeField] private Image DialogueBox; 
    [SerializeField] private Text txt_Dialogue; 

    private bool isDialogue = false; 
    private int count= 0;

    [SerializeField] private Dialogue3[] dialogue3;

    QuestPoint questPoint;
             
    private void Start()
    {
        questPoint = GetComponent<QuestPoint>();

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
       
        txt_Dialogue.text = dialogue3[count].dialogue3;
        count++;

    }


   
    void Update()
    {
        if (isDialogue ) 
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
              
                if (count < dialogue3.Length ) NextDialogue();
                else ONOFF(false);         
            }
        }
       

  
    }

}