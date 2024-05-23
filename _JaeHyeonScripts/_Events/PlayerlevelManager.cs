using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerlevelManager : MonoBehaviour
{
    [SerializeField]
    private STD PlayerSTD;

    [Header("Configuration")]
    [SerializeField] private int startingLevel = 1;
   
    [SerializeField] private int startingExperience = 0;

    public GameObject levelupeffect;
    public TMP_Text LevelTe;
    Animator ani;
  
    private void Awake()
    {
         ani = levelupeffect.GetComponent<Animator>();
    }

    private void Start()
    {

        PlayerSTD.level = startingLevel;
        PlayerSTD.exp = startingExperience;

        GameEventManager.instance.playerEvents.onExperienceGained += ExperienceGained;
        GameEventManager.instance.playerEvents.PlayerLevelChange(PlayerSTD.level);
        GameEventManager.instance.playerEvents.PlayerExperienceChange(PlayerSTD.exp);




        levelupeffect.SetActive(false);

    }
  
    private void OnDisable()
    {
        GameEventManager.instance.playerEvents.onExperienceGained -= ExperienceGained;    
    }

 
    IEnumerator LevelupEffect()
    {     
        levelupeffect.SetActive(true);
        ani.SetTrigger("UP");
        LevelTe.text = string.Format("         {0}", PlayerSTD.level);
        SoundManager.instance.Play(UISOUND.LevelUp);
        yield return new WaitForSeconds(3.5f);
        levelupeffect.SetActive(false);
    }
    private void ExperienceGained(int experience)
    {

        PlayerSTD.exp += experience;  //현제 경험치에 획득 경험치를 더한다
       
        while (PlayerSTD.exp >= PlayerSTD.nextExp)
        {

            PlayerSTD.exp -= PlayerSTD.nextExp;
            PlayerSTD.level++;
            PlayerSTD.abilityPoint += 5;
            GameEventManager.instance.playerEvents.PlayerLevelChange(PlayerSTD.level);
            StartCoroutine(LevelupEffect());
        }
        GameEventManager.instance.playerEvents.PlayerExperienceChange(PlayerSTD.exp);

    }

    private void Update()
    {
        switch (PlayerSTD.level) //레벨 별 경험치
        {
            case 1:
                PlayerSTD.nextExp = 100;
           
                break;
            case 2:
                PlayerSTD.nextExp = 125;
              
                break;
            case 3:
                PlayerSTD.nextExp = 150;
    
                break;
            case 4:
                PlayerSTD.nextExp = 200;
                break;

            default:
                PlayerSTD.nextExp = 500;
                break;
        }      
    }
}

