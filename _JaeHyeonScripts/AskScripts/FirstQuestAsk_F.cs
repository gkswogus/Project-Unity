using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(AudioSource))]
public class FirstQuestAsk_F : MonoBehaviour
{
    FirstQuestAskFinish asktest;

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
        asktest = GetComponent<FirstQuestAskFinish>();
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

        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (NearView() && questPoint.currentQuestState.Equals(QuestState.CAN_FINISH))
            {
                asktest.ShowDialogue();
                SoundManager.instance.Play(GAMESOUND.Interaction, audioS);
            }
        }
    }
  

}
