using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestStep : MonoBehaviour //추상클래스 ( 오직  상속만을 위한 - abstract)
{
    private bool isFinished = false;
    private string questId;
    private int stepIndex;
    public void IntiallzeQuestStep(string questId,int stepIndex, string questStepState)
    {
        this.questId = questId;
        this.stepIndex = stepIndex;
        if(questStepState !=null && questStepState != "")
        {
            SetQuestStepState(questStepState);
        }
    }
    
    protected void FinishQuestStep()
    {
        if (!isFinished)
        { 
            isFinished = true;
            GameEventManager.instance.questEvents.AdvanceQuest(questId);
            Destroy(this.gameObject);
        }
    }
    
    protected void ChangeState(string newState)
    {
        GameEventManager.instance.questEvents.QuestStepStateChange(questId, stepIndex, new QuestStepState(newState));
    }

    protected abstract void SetQuestStepState(string state);
}
