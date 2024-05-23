using UnityEngine;
using System;


public class InputEvents
{

    public event Action onSubmitPressed;
    public void SubmitPressed()
    {
        if (onSubmitPressed != null)
        {
            onSubmitPressed();
        }
    }
    //=================================
    public event Action OnQuestWindowOn_Off;
    public void QuestWindowOn_Off()
    {
        if (OnQuestWindowOn_Off != null)
        {
            OnQuestWindowOn_Off();
        }
    }
    //=================================
    public event Action OnUpgradeWindow_On_Off;

    public void UpgradeWindow_On_Off()
    {
        if (OnUpgradeWindow_On_Off != null)
        {
            OnUpgradeWindow_On_Off();
        }
    }
    //=================================
    public event Action OnSTDWindowOn_OFF;
    public void STDWindowOn_OFF()
    {
        if (OnSTDWindowOn_OFF != null)
        {
            OnSTDWindowOn_OFF();
        }
    }
    //=================================
    public event Action OnInventoryOn_OFF;
    public void InventoryOn_OFF()
    {
        if(OnInventoryOn_OFF != null)
        {
            OnInventoryOn_OFF();
        }
    }
    //================================
    public event Action OnShopOn_OFF;
    public void ShopOn_OFF()
    {
        if (OnShopOn_OFF != null)
        {
            OnShopOn_OFF();
        }
    }
}