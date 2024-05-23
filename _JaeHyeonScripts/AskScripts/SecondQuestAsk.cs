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
   
    bool NearView() // �þ� üũ
    {
        distance = Vector3.Distance(transform.position, player.transform.position); //�Ÿ� ���
        direction = transform.position - player.transform.position;// player�� ������ ���̰�
        angleView = Vector3.Angle(player.transform.forward, direction); //�ٶ󺸴� ������ ȸ���� ���ϱ�
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
