using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScondsNpcAsk2_ : MonoBehaviour
{

    [SerializeField] private TMP_Text txt_alam1;

    SecondsNpcAsk2 scNpcAsk2;

    GameObject questManager;

    AudioSource audioS;
    private void Awake()
    {
        audioS = this.gameObject.GetComponent<AudioSource>();
    }
    private void Start()
    {
        txt_alam1.gameObject.SetActive(false);

        scNpcAsk2 = GetComponent<SecondsNpcAsk2>();

        questManager = GameObject.Find("QuestManager");
    }

    private void OnCollisionStay(Collision col)
    {

        if (col.gameObject.tag == "Player" && questManager.GetComponent<QuestManager>().currentPlayerLevel == 3)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                SoundManager.instance.Play(GAMESOUND.Interaction, audioS);

                Destroy(txt_alam1);
                scNpcAsk2.ShowDialogue1();
            }
        }
    }
    private void Update()
    {
       
        if (txt_alam1 != null)
        {
            if (questManager.GetComponent<QuestManager>().currentPlayerLevel == 3)
            {
                txt_alam1.gameObject.SetActive(true);
            }
        }
    }
}
