using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstQuestStep : QuestStep
{
    private int KillMonster = 0;     //초기 값 0 
    private int CompleteKillMonster = 3; // 완료 몬스터 처치 수 

    private void OnEnable()
    {
       GameEventManager.instance.miscEvents.onKillMonstered += KillMonstered;
        gameObject.tag = "FirstQuest";
    }
    private void OnDisable()
    {  
        GameEventManager.instance.miscEvents.onKillMonstered -= KillMonstered;
    }

    private void KillMonstered()
    {
        if(KillMonster < CompleteKillMonster)
        {
            KillMonster++;
            UpdateState();  
        }

        if (KillMonster >= CompleteKillMonster)
        {
            FinishQuestStep();
        }
    }
    
    private void UpdateState()
    {
        string state = KillMonster.ToString();
        ChangeState(state);
    }

    protected override void SetQuestStepState(string state)
    {
        this.KillMonster = System.Int32.Parse(state);
        UpdateState();
    }
}
