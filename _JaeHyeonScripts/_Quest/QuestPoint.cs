using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestPoint : MonoBehaviour
{
    [Header("Quest")]
    [SerializeField] private QuestInfo questInfoForPoint;

    [Header("Config")]
    [SerializeField] private bool startPoint = true;
    [SerializeField] private bool finishPoint =true;

    private bool PlayerMeet = false;

    private string questId;

  
    public  QuestState currentQuestState;
 

    private QuestIcon questIcon;

    [Header("@@@@퀘스트 보상창@@@@")]
    [SerializeField] GameObject reWard;

    Transform player;
    float distance;
    float angleView;
    Vector3 direction;
    private void Awake()
    {
        reWard.SetActive(false);

        player = GameObject.FindWithTag("Player").GetComponent<Transform>();

        questId = questInfoForPoint.id;
        questIcon = GetComponentInChildren<QuestIcon>();
    }

  
    private void OnEnable()
    {
        GameEventManager.instance.questEvents.onQuestStateChange += QuestStateChange;
        GameEventManager.instance.inputEvents.onSubmitPressed += submitPressed;
    }

    private void OnDisable()
    {
        GameEventManager.instance.questEvents.onQuestStateChange -= QuestStateChange;
        GameEventManager.instance.inputEvents.onSubmitPressed -= submitPressed;
    }

    private void submitPressed()
    {

        if (NearView())
        {
            if (currentQuestState.Equals(QuestState.CAN_START) && startPoint)
            {
                GameEventManager.instance.questEvents.StartQuest(questId);
            }
            else if (currentQuestState.Equals(QuestState.CAN_FINISH) && finishPoint)
            {
                reWard.SetActive(true);
                UIEventControll.instance.isOnUI = UIEventControll.instance.isOnUI = true;
               
            }
        }
    
    }
    public void reWardGet() //보상 확인 버튼
    {
        if (currentQuestState.Equals(QuestState.CAN_FINISH) && finishPoint)
        {
            GameEventManager.instance.questEvents.FinishQuest(questId);
            reWard.SetActive(false);
            SoundManager.instance.Play(UISOUND.QuestC);
            UIEventControll.instance.isOnUI = UIEventControll.instance.isOnUI = false ;
        }
    }
    private void QuestStateChange(Quest quest)
    {
        if (quest.info.id.Equals(questId))
        {
            currentQuestState = quest.state;
            questIcon.SetState(currentQuestState, startPoint, finishPoint);
        }
    }

    bool NearView() 
    {
        distance = Vector3.Distance(transform.position, player.transform.position); 
        direction = transform.position - player.transform.position;
        angleView = Vector3.Angle(player.transform.forward, direction); 
        if (angleView < 45f && distance < 5f)
            return true;
        else return false;
    }
    


}
