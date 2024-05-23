using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondQuestStep : QuestStep
{
    private int KillMonsterMN = 0;     //�ʱ� �� 0
    private int CompleteKillMonsterMN = 1; // �Ϸ� ���� óġ �� 

    private void OnEnable()
    {
        GameEventManager.instance.miscEvents.onKillMonsteredMN += KillMonsteredMN;
        gameObject.tag = "SecondQuest";
    }
    private void OnDisable()
    {
        GameEventManager.instance.miscEvents.onKillMonsteredMN -= KillMonsteredMN;
    }

    private void KillMonsteredMN()
    {
        if (KillMonsterMN < CompleteKillMonsterMN)
        {
            KillMonsterMN++;
            UpdateState();
        }

        if (KillMonsterMN >= CompleteKillMonsterMN)
        {
            FinishQuestStep();
        }
    }

    private void UpdateState()
    {
        string state = KillMonsterMN.ToString();
        ChangeState(state);
    }

    protected override void SetQuestStepState(string state)
    {
        this.KillMonsterMN = System.Int32.Parse(state);
        UpdateState();
    }
}
