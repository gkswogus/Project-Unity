using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class FirstNpcAsk_ : MonoBehaviour
{
    FirstNpcAsk asktest;

    [SerializeField] private TMP_Text txt_alam;

    bool tipOn = true;

    AudioSource a;
    private void Awake()
    {
      
    }
    private void Start()
    {
        asktest = GetComponent<FirstNpcAsk>();
        txt_alam.gameObject.SetActive(true);

        a = this.gameObject.GetComponent<AudioSource>();
    }
    private void OnDisable()
    {
        
    }




    private void OnCollisionStay(Collision col)
    {
        if (asktest.CompleteFirstAsk == false)
        {
            if (col.gameObject.tag == "Player")
            {
                if(tipOn)
                TollTipmanager.instance.TollTip.SetActive(true);
                TollTipmanager.instance.TollTipTxt.text = string.Format("Y키를 통해 특정 NPC와 상호작용 할 수 있습니다."); 

                if (Input.GetKeyDown(KeyCode.Y))
                {
                    SoundManager.instance.Play(GAMESOUND.Interaction, a);

                    tipOn = false;
                    TollTipmanager.instance.TollTip.SetActive(false);
                    txt_alam.gameObject.SetActive(false);
                    asktest.ShowDialogue();
                }
            }
        }

        if (asktest.CompleteFirstAsk == true)
        {
            if (col.gameObject.tag == "Player")
            {
                
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    SoundManager.instance.Play(GAMESOUND.Interaction, a);

                    Destroy(txt_alam);
                    asktest.ShowDialogue();
                }
            }
        }
    }

        private void Update()
        {
            if (txt_alam != null)
            {
                if (asktest.CompleteFirstAsk == true) txt_alam.gameObject.SetActive(true);
            }

        }
    
}