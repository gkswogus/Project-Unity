using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(AudioSource))]
public class FirstQuestAsk_ : MonoBehaviour
{
    FirstQuestAskStart asktest;

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

        asktest = GetComponent<FirstQuestAskStart>();
        questPoint = GetComponent<QuestPoint>();

    }
 
    bool NearView1() // 시야 체크
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
        if (NearView1() && questPoint.currentQuestState.Equals(QuestState.IN_PROGRESS))
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                asktest.ShowDialogue();
                SoundManager.instance.Play(GAMESOUND.Interaction, audioS);
            }
        }
    }
 
}
