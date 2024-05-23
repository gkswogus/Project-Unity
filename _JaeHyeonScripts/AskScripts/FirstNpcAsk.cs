using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Text field를 사용할 수 있도록 하는 header

[System.Serializable] //직접 만든 class에 접근할 수 있도록 해줌. 
public class Dialogue1 //첫번째 대화
{
    [TextArea]//한줄 말고 여러 줄 쓸 수 있게 해줌
    public string dialogue1;
}

public class FirstNpcAsk : MonoBehaviour
{

    
    [SerializeField] private Image DialogueBox; //대사창 이미지(crop)를 제어하기 위한 변수
    [SerializeField] private Text txt_Dialogue; // 텍스트를 제어하기 위한 변수

    private bool isDialogue = false; //대화가 진행중인지 알려줄 변수
    public int count = 0; //대사가 얼마나 진행됐는지 알려줄 변수

  
    public Dialogue1[] dialogue1;


    public bool CompleteFirstAsk;

    bool onoff = true;

    [Header("장비")]
   

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
        ONOFF(true); //대화가 시작됨
        
        NextDialogue(); //호출되자마자 대사가 진행될 수 있도록 
    }
    
    private void ONOFF(bool _flag)
    {
        DialogueBox.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        isDialogue = _flag;
    }

    private void NextDialogue()
    {
        //첫번째 대사와 첫번째 cg부터 계속 다음 cg로 진행되면서 화면에 보이게 된다. 
        txt_Dialogue.text = dialogue1[count].dialogue1;
        count++; //다음 대사와 cg가 나오도록 
       
    }


   
    void Update()
    {
        if (isDialogue) //활성화가 되었을 때만 대사가 진행되도록
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (!CompleteFirstAsk)
                {
                    if (count < dialogue1.Length - 2) NextDialogue(); //다음 대사가 진행됨
                    else ONOFF(false); //대사가 끝남
                  
                    for(int i=0; i<Jangbe.Length; i++)
                    {
                        Jangbe[i].SetActive(true);
                    }
                    
                }
                if (CompleteFirstAsk)
                {
                    if (count < dialogue1.Length) NextDialogue(); //다음 대사가 진행됨
                    else ONOFF(false); //대사가 끝남 
                }                                
            }
        }
        if (count == 4)
        {
            if (onoff)
            {
                TollTipmanager.instance.TollTip.SetActive(true);
                TollTipmanager.instance.TollTipTxt.text = string.Format("E키 를 통해 장비를 획득한 뒤, I키를 통해 인벤토리 에서 아이템을 착용 할 수 있습니다.");
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                CompleteFirstAsk = true;
                onoff = false;
                TollTipmanager.instance.TollTip.SetActive(false);
            }
        }
    }

     //   count ==>  첫번째 대화가 끝나면 3스택
    }

