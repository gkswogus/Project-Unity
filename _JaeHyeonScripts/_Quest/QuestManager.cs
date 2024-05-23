using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class QuestManager : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private bool loadQuestState = true;

    private Dictionary<string, Quest> questMap;

    public int currentPlayerLevel;
   
    [Header("보상 텍스트 테스트")]
    public TMP_Text goldRewardText;
    public TMP_Text expRewardText;


    private void Awake()
    {
        questMap = CreateQuestMap();
    }
   
    private void OnEnable()
    {
        GameEventManager.instance.questEvents.onStartQuest += StartQuest;
        GameEventManager.instance.questEvents.onAdvanceQuest += AdvanceQuest;
        GameEventManager.instance.questEvents.onFinishQuest += FinishQuest;

        GameEventManager.instance.questEvents.onQuestStepStateChange += QuestStepStateChange;

        GameEventManager.instance.playerEvents.onPlayerLevelChange += PlayerLevelChange;
    }

    private void OnDisable()
    {
        GameEventManager.instance.questEvents.onStartQuest -= StartQuest;
        GameEventManager.instance.questEvents.onAdvanceQuest -= AdvanceQuest;
        GameEventManager.instance.questEvents.onFinishQuest -= FinishQuest;

        GameEventManager.instance.questEvents.onQuestStepStateChange -= QuestStepStateChange;

        GameEventManager.instance.playerEvents.onPlayerLevelChange -= PlayerLevelChange;
    }


    private void Start()
    {
        foreach (Quest quest in questMap.Values)
        {
            if (quest.state == QuestState.IN_PROGRESS)
            {
                quest.InstantiateCurrentQuestStep(this.transform);
            }
            GameEventManager.instance.questEvents.QuestStateChange(quest);
        }
  
    }
    private void ChangeQuestState(string id, QuestState state)
    {
        Quest quest = GetQuestById(id);
        quest.state = state;
        GameEventManager.instance.questEvents.QuestStateChange(quest);
    }

    private void PlayerLevelChange(int level)
    {
        currentPlayerLevel = level;
    }
     private bool CheckRequirementsMet(Quest quest) //퀘스트 요구사항 충족하는지 체크
    {
        
        bool meetsRequirements = true;

       
        if (currentPlayerLevel < quest.info.levelRequirement)
        {
            meetsRequirements = false;
        }

      
        foreach (QuestInfo prerequisiteQuestInfo in quest.info.questPrerequistes)
        {
            if (GetQuestById(prerequisiteQuestInfo.id).state != QuestState.FINISHED)
            {
                meetsRequirements = false;
                break;
            }
        }

        return meetsRequirements;
    }

    private void Update()
    {
     
    
        foreach (Quest quest in questMap.Values)
        {
           
            if (quest.state == QuestState.REQUIREMENTS_NOT_MET && CheckRequirementsMet(quest))
            {
                ChangeQuestState(quest.info.id, QuestState.CAN_START);
            }

        }

            if (this.transform.childCount != 0)
            {
                if (this.transform.GetChild(0).tag == "FirstQuest")
                {
                    goldRewardText.text = string.Format("{0}", 300);
                    expRewardText.text = string.Format("{0}", 115);           
                }
                if (this.transform.GetChild(0).tag == "SecondQuest")
                {
                    goldRewardText.text = string.Format("{0}", 600);
                    expRewardText.text = string.Format("{0}", 200);
                }
            }
    }

    private void StartQuest(string id)
    {
        Quest quest = GetQuestById(id);
        quest.InstantiateCurrentQuestStep(this.transform);
        ChangeQuestState(quest.info.id, QuestState.IN_PROGRESS);
    }

    private void AdvanceQuest(string id)
    {
        Quest quest = GetQuestById(id);

        quest.MoveToNextStep();

        if (quest.CurrentStepExists())
        {
            quest.InstantiateCurrentQuestStep(this.transform);
        }
        else
        {
            ChangeQuestState(quest.info.id, QuestState.CAN_FINISH);
        }
    }

    private void FinishQuest(string id)
    {
        Quest quest = GetQuestById(id);
        claimRewards(quest);
        ChangeQuestState(quest.info.id, QuestState.FINISHED);

    }

    private void claimRewards(Quest quest)  //보상 시스템  경험치,골드
    {
  
        GameEventManager.instance.goldEvents.GoldGained(quest.info.goldReward);
        GameEventManager.instance.playerEvents.ExperienceGained(quest.info.expReward);
   
    }

    private void QuestStepStateChange(string id, int stepIndex, QuestStepState questStepState)
    {
        Quest quest = GetQuestById(id);
        quest.StoreQuestStepState(questStepState, stepIndex);
        ChangeQuestState(id, quest.state);
    }

    private Dictionary<string, Quest> CreateQuestMap()
    {
       QuestInfo[] allQuests = Resources.LoadAll<QuestInfo>("Quests");
     
        Dictionary<string, Quest> idToQuestMap = new Dictionary<string, Quest>();
        foreach (QuestInfo questInfo in allQuests)
        {
          
            idToQuestMap.Add(questInfo.id,  LoadQuest(questInfo));
        }
        return idToQuestMap;
    }

    private Quest GetQuestById(string id)
    {
        Quest quest = questMap[id];
     
        return quest;
    }

    private void OnApplicationQuit() //종료시 실행
    {
        foreach(Quest quest in questMap.Values)
        {
            SaveQuest(quest);
        }
    }
    
    private void SaveQuest(Quest quest)
    {
        try
        {
            QuestData questData = quest.GetQuestData();
          
            string serializedData = JsonUtility.ToJson(questData);
          
            PlayerPrefs.SetString(quest.info.id, serializedData);
        }
        catch (System.Exception e)
        {
           
        }
    }

    private Quest LoadQuest(QuestInfo questInfo)
    {
        Quest quest = null;
        try 
        {
           
            if (PlayerPrefs.HasKey(questInfo.id)&& loadQuestState)
            {
                string serializedData = PlayerPrefs.GetString(questInfo.id);
                QuestData questData = JsonUtility.FromJson<QuestData>(serializedData);
                quest = new Quest(questInfo, questData.state, questData.questStepIndex, questData.questStepStates);
            }
         
            else
            {
                quest = new Quest(questInfo);
            }
        }
        catch (System.Exception e)
        {
           
        }
        return quest;
    }
}
