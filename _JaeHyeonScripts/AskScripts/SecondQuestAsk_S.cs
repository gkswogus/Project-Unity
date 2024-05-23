using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable] 
public class Dialogue5
{
    [TextArea]
    public string dialogue5;
}



public class SecondQuestAsk_S : MonoBehaviour
{

    [SerializeField] private Image DialogueBox;
    [SerializeField] private Text txt_Dialogue; 

    private bool isDialogue = false;
    private int count = 0; 

    [SerializeField] private Dialogue5[] dialogue5;





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
        
        txt_Dialogue.text = dialogue5[count].dialogue5;
        count++; 

    }


    
    void Update()
    {
        if (isDialogue) 
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
              
                if (count < dialogue5.Length) NextDialogue(); 
                else
                {
                    SoundManager.instance.Play(UISOUND.QuestO);
                    ONOFF(false);        
                }
            }
        }



    }

}