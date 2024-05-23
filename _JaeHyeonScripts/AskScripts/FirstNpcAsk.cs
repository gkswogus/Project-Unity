using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Text field�� ����� �� �ֵ��� �ϴ� header

[System.Serializable] //���� ���� class�� ������ �� �ֵ��� ����. 
public class Dialogue1 //ù��° ��ȭ
{
    [TextArea]//���� ���� ���� �� �� �� �ְ� ����
    public string dialogue1;
}

public class FirstNpcAsk : MonoBehaviour
{

    
    [SerializeField] private Image DialogueBox; //���â �̹���(crop)�� �����ϱ� ���� ����
    [SerializeField] private Text txt_Dialogue; // �ؽ�Ʈ�� �����ϱ� ���� ����

    private bool isDialogue = false; //��ȭ�� ���������� �˷��� ����
    public int count = 0; //��簡 �󸶳� ����ƴ��� �˷��� ����

  
    public Dialogue1[] dialogue1;


    public bool CompleteFirstAsk;

    bool onoff = true;

    [Header("���")]
   

    [SerializeField] private GameObject[] Jangbe;

    private void Awake()
    {
        for (int i = 0; i < Jangbe.Length; i++)
        {
            Jangbe[i].SetActive(false);
        }

    }

    private void Start()
    {
        DialogueBox.gameObject.SetActive(false);
        txt_Dialogue.gameObject.SetActive(false);
    }
    public void ShowDialogue()
    {
        if(!CompleteFirstAsk) count = 0;
        if (CompleteFirstAsk) count = 4;
        ONOFF(true); //��ȭ�� ���۵�
        
        NextDialogue(); //ȣ����ڸ��� ��簡 ����� �� �ֵ��� 
    }
    
    private void ONOFF(bool _flag)
    {
        DialogueBox.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        isDialogue = _flag;
    }

    private void NextDialogue()
    {
        //ù��° ���� ù��° cg���� ��� ���� cg�� ����Ǹ鼭 ȭ�鿡 ���̰� �ȴ�. 
        txt_Dialogue.text = dialogue1[count].dialogue1;
        count++; //���� ���� cg�� �������� 
       
    }


   
    void Update()
    {
        if (isDialogue) //Ȱ��ȭ�� �Ǿ��� ���� ��簡 ����ǵ���
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (!CompleteFirstAsk)
                {
                    if (count < dialogue1.Length - 2) NextDialogue(); //���� ��簡 �����
                    else ONOFF(false); //��簡 ����
                  
                    for(int i=0; i<Jangbe.Length; i++)
                    {
                        Jangbe[i].SetActive(true);
                    }
                    
                }
                if (CompleteFirstAsk)
                {
                    if (count < dialogue1.Length) NextDialogue(); //���� ��簡 �����
                    else ONOFF(false); //��簡 ���� 
                }                                
            }
        }
        if (count == 4)
        {
            if (onoff)
            {
                TollTipmanager.instance.TollTip.SetActive(true);
                TollTipmanager.instance.TollTipTxt.text = string.Format("EŰ �� ���� ��� ȹ���� ��, IŰ�� ���� �κ��丮 ���� �������� ���� �� �� �ֽ��ϴ�.");
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                CompleteFirstAsk = true;
                onoff = false;
                TollTipmanager.instance.TollTip.SetActive(false);
            }
        }
    }

     //   count ==>  ù��° ��ȭ�� ������ 3����
    }

