using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(AudioSource))]
public class SecondQuestAsk : MonoBehaviour
{
    SecondQuestAsk_S asktest;
    SecondQuestAsk_F asktest2;

    QuestPoint questPoint;

    AudioSource audioS;

    Transform player;
    float distance;
    float angleView;
    Vector3 direction;
    private void Awake()
    {
        audioS = this.gameObject.GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    private void Start()
    {
        asktest = GetComponent<SecondQuestAsk_S>();
        asktest2 = GetComponent<SecondQuestAsk_F>();
        questPoint = GetComponent<QuestPoint>();
    }
   
    bool NearView() // 시야 체크
    {
        distance = Vector3.Distance(transform.position, player.transform.position); //거리 재기
        direction = transform.position - player.transform.position;// player과 몬스터의 사이값
        angleView = Vector3.Angle(player.transform.forward, direction); //바라보는 방향의 회전값 구하기
        if (angleView < 45f && distance < 5f)
            return true;
        else return false;
    }

    private void Update()
    {
        if (NearView() && questPoint.currentQuestState.Equals(QuestState.IN_PROGRESS))
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                SoundManager.instance.Play(GAMESOUND.Interaction, audioS);
                asktest.ShowDialogue();
            }
        }
      
            if (Input.GetKeyDown(KeyCode.Y))
        {
            if (NearView() && questPoint.currentQuestState.Equals(QuestState.CAN_FINISH))
            {
                SoundManager.instance.Play(GAMESOUND.Interaction, audioS);
                asktest2.ShowDialogue2();
            }
        }
    }
  
}
