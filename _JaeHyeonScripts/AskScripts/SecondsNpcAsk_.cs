using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(AudioSource))]
public class ScondsNpcAsk_ : MonoBehaviour
{

    [SerializeField] private TMP_Text txt_alam;

    GameObject npc1;

    SecondsNpcAsk scNpcAsk;

    GameObject questManager;

    AudioSource audioS;
    private void Awake()
    {
        audioS = this.gameObject.GetComponent<AudioSource>();
    }
    private void Start()
    {
        npc1 = GameObject.Find("NPC(±â»ç)");

        txt_alam.gameObject.SetActive(false);

        scNpcAsk = GetComponent<SecondsNpcAsk>();

        questManager = GameObject.Find("QuestManager");
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Player"&& npc1.GetComponent<FirstNpcAsk>().count == npc1.GetComponent<FirstNpcAsk>().dialogue1.Length&&
            questManager.GetComponent<QuestManager>().currentPlayerLevel == 1)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                SoundManager.instance.Play(GAMESOUND.Interaction, audioS);
                Destroy(txt_alam);
                scNpcAsk.ShowDialogue(); 
            }
        }
    }
   
    private void Update()
    {
        if (txt_alam != null)
        {
            if (npc1.GetComponent<FirstNpcAsk>().count == npc1.GetComponent<FirstNpcAsk>().dialogue1.Length)
            {
                txt_alam.gameObject.SetActive(true);
            }
        }
    }
}
