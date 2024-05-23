using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MainUiM : MonoBehaviour
{
  
    public Text Gd;
    
    private int maxExp;

    GameObject playerlevel;
   
   
    STD playerInfoo;
    GameObject BuyItem;
   
    int Exp;
    int Lvel;
  
   
    private void Awake()
    {
     

        playerInfoo = GameObject.FindWithTag("Player").GetComponent<STD>();
        BuyItem = GameObject.Find("AllManager");
      

        playerlevel = GameObject.Find("PlayerlevelManager");
       

    }

    private void Update()
    {
 
        Gd.text = string.Format("{0}", playerInfoo.money);
    }
 
}
