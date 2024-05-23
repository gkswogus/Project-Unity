using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class QusetUiManager : MonoBehaviour
{
    QuestUiOnOff qof;
    [Header("첫번 째 퀘스트")]
    public GameObject[] First;
    public GameObject[] FirstF;
    [SerializeField] private GameObject FirstQuestNPCS;
    [SerializeField] private GameObject FirstQuestNPCF;
    public bool OnFirst = false; //퀘스트 정보창+진행상황창
    public bool OnFirstF = false; //퀘스트 완료창
    public TextMeshProUGUI FirstQuestText;
    int KilledM = 3;
    int KillM = 0;
  
    private void Awake()
    {
        for (int i = 0; i < First.Length; i++)
        {
            First[i].SetActive(OnFirst);
        }
        FirstF[0].SetActive(OnFirstF);
       
        qof = GetComponent<QuestUiOnOff>();
    }
    private void OnEnable()
    {
        GameEventManager.instance.miscEvents.onKillMonstered += KillMonstered;
    }
    private void OnDisable()
    {
        GameEventManager.instance.miscEvents.onKillMonstered -= KillMonstered;
    }
    private void KillMonstered()
    {
        if (KillM < KilledM)
        {
            KillM++;
        }

        if (KillM >= KilledM)
        {
            KillM = KilledM;
        }
    }
  

    private void Update()
    {
        if (FirstQuestNPCF.GetComponent<QuestPoint>().currentQuestState == QuestState.FINISHED)
        {
            for (int i = 0; i < First.Length; i++)
            {
                Destroy(First[i]);
            }
        }

        FirstQuestText.text = string.Format(" 악마 : {0} / {1}", KillM, KilledM);

        if (FirstQuestNPCS.GetComponent<QuestPoint>().currentQuestState == QuestState.IN_PROGRESS && qof.isChoose == true ||
      FirstQuestNPCS.GetComponent<QuestPoint>().currentQuestState == QuestState.CAN_FINISH && qof.isChoose == true)
        {
           
                for (int i = 0; i < First.Length; i++)
                {
                    First[i].SetActive(true);
                }
           
        }
        if (FirstQuestNPCS.GetComponent<QuestPoint>().currentQuestState == QuestState.IN_PROGRESS && qof.isChoose == false ||
      FirstQuestNPCS.GetComponent<QuestPoint>().currentQuestState == QuestState.CAN_FINISH && qof.isChoose == false)
        {
            for (int i = 0; i < First.Length; i++)
            {
                First[i].SetActive(false);
            }
        }
        if (FirstQuestNPCF.GetComponent<QuestPoint>().currentQuestState == QuestState.FINISHED && qof.isChoose1 == true)
            FirstF[0].SetActive(true);
        if (FirstQuestNPCF.GetComponent<QuestPoint>().currentQuestState == QuestState.FINISHED && qof.isChoose1 == false)
            FirstF[0].SetActive(false);

    }
 
}
