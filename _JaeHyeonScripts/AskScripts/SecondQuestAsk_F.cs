using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable] 
public class Dialogue6
{
    [TextArea]
    public string dialogue6;
}



public class SecondQuestAsk_F : MonoBehaviour
{

    [SerializeField] private Image DialogueBox; 
    [SerializeField] private Text txt_Dialogue;

    private bool isDialogue = false; 
    private int count = 0; 

    [SerializeField] private Dialogue6[] dialogue6;





    public void ShowDialogue2()
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
       
        txt_Dialogue.text = dialogue6[count].dialogue6;
        count++; 

    }



    void Update()
    {
        if (isDialogue) 
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
              
                if (count < dialogue6.Length) NextDialogue(); 
                else ONOFF(false);         
            }
        }



    }

}