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
 
    bool NearView1() // �þ� üũ
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
