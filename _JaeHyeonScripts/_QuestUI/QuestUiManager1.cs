using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class QusetUiManager1 : MonoBehaviour
{
    QuestUiOnOff qof;
    [Header("두번 째 퀘스트")]
    public GameObject[] Second;
    public GameObject[] SecondF;
    [SerializeField] private GameObject SecondQuestNPCS;
    public  bool OnSecond = false; //퀘스트 진행창+진행상황창
    public bool OnSecondF = false;//퀘스트 완료창
    public TextMeshProUGUI SecondQuestText;
    int KilledMN = 1;
    int KillMN = 0;



    private void Awake()
    {
        for (int i = 0; i < Second.Length; i++)
        {
            Second[i].SetActive(OnSecond);
        }
        SecondF[0].SetActive(OnSecondF);
      
        qof = GetComponent<QuestUiOnOff>();
    }
    private void OnEnable()
    {
        GameEventManager.instance.miscEvents.onKillMonsteredMN += KillMonsteredMN;
    }
    private void OnDisable()
    {
        GameEventManager.instance.miscEvents.onKillMonsteredMN -= KillMonsteredMN;
    }
    private void KillMonsteredMN()
    {
        if (KillMN < KilledMN)
        {
            KillMN++;
        }

        if (KillMN >= KilledMN)
        {
            KillMN = KilledMN;
        }
    }
 
    private void Update()
    {
        if (SecondQuestNPCS.GetComponent<QuestPoint>().currentQuestState == QuestState.FINISHED)
        {
            for (int i = 0; i < Second.Length; i++)
            {
                Destroy(Second[i]);
            }
        }

        SecondQuestText.text = string.Format("  황소 : {0} / {1}", KillMN, KilledMN);

        if (SecondQuestNPCS.GetComponent<QuestPoint>().currentQuestState == QuestState.IN_PROGRESS && qof.isChoose == true ||
    SecondQuestNPCS.GetComponent<QuestPoint>().currentQuestState == QuestState.CAN_FINISH && qof.isChoose == true)
        {

            for (int i = 0; i < Second.Length; i++)
            {
                Second[i].SetActive(true);
            }

        }
        if (SecondQuestNPCS.GetComponent<QuestPoint>().currentQuestState == QuestState.IN_PROGRESS && qof.isChoose == false ||
      SecondQuestNPCS.GetComponent<QuestPoint>().currentQuestState == QuestState.CAN_FINISH && qof.isChoose == false)
        {
            for (int i = 0; i < Second.Length; i++)
            {
                Second[i].SetActive(false);
            }
        }
        if (SecondQuestNPCS.GetComponent<QuestPoint>().currentQuestState == QuestState.FINISHED&&qof.isChoose1==true)
            SecondF[0].SetActive(true);
        if (SecondQuestNPCS.GetComponent<QuestPoint>().currentQuestState == QuestState.FINISHED && qof.isChoose1 == false)
            SecondF[0].SetActive(false);
    }
}
