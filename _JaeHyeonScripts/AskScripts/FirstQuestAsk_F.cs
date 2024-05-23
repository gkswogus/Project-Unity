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
