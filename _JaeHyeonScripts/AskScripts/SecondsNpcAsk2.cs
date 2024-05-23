using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable] 
public class Dialogue4
{
    [TextArea]
    public string dialogue4;
}
public class SecondsNpcAsk2 : MonoBehaviour
{

    [SerializeField] private Image DialogueBox1; 
    [SerializeField] private Text txt_Dialogue1;

    private bool isDialogue = false; 
    private int count1 = 0; 

    [SerializeField] private Dialogue4[] dialogue4;

    

    private void Start()
    {
        DialogueBox1.gameObject.SetActive(false);
        txt_Dialogue1.gameObject.SetActive(false);
    }

    public void ShowDialogue1()
    {
        ONOFF(true); 
        count1 = 0;
        NextDialogue1(); 
    }

    private void ONOFF(bool _flag)
    {
        DialogueBox1.gameObject.SetActive(_flag);
        txt_Dialogue1.gameObject.SetActive(_flag);
        isDialogue = _flag;
    }

    private void NextDialogue1()
    {
        
        txt_Dialogue1.text = dialogue4[count1].dialogue4;
        count1++; 
    }


  
    void Update()
    {
        if (isDialogue)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
             
                if (count1 < dialogue4.Length) NextDialogue1(); 
                else
                {
                    ONOFF(false);
                }
            }
        }
    }

}