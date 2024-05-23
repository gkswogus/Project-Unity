using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private int startingGold = 50000;

    public int currentGold { get; private set; }

    STD PlayerInfo1;

    private void Awake()
    {      
        PlayerInfo1 = GameObject.FindWithTag("Player").GetComponent<STD>();
    }

    private void Start()
    {
        GameEventManager.instance.goldEvents.onGoldGained += GoldGained;
        GameEventManager.instance.goldEvents.GoldChange(PlayerInfo1.money);
        PlayerInfo1.money = startingGold;
    }

    private void OnEnable()
    {
       
    }

    private void OnDisable()
    {
        GameEventManager.instance.goldEvents.onGoldGained -= GoldGained;
    }

   

    private void GoldGained(int gold)
    {

         PlayerInfo1.money += gold;
        GameEventManager.instance.goldEvents.GoldChange(PlayerInfo1.money);
    }
   
}
