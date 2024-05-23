using UnityEngine;
using UnityEngine.InputSystem;



public class InputManager : MonoBehaviour
{
    public void SubmitPressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GameEventManager.instance.inputEvents.SubmitPressed();
        }
    }

    //======
    public void QuestWindowOn_Off(InputAction.CallbackContext context)
    { 
            GameEventManager.instance.inputEvents.QuestWindowOn_Off();
    }
    //======
    public void UpgradeWindow_On_Off(InputAction.CallbackContext context)
    {
        GameEventManager.instance.inputEvents.UpgradeWindow_On_Off();
    }
    //======
    public void STDWindowOn_OFF(InputAction.CallbackContext context)
    {
        if(context.started)
        GameEventManager.instance.inputEvents.STDWindowOn_OFF();
    }
    //======
    public void InventoryOn_OFF(InputAction.CallbackContext context)
    {
        if (context.started)
            GameEventManager.instance.inputEvents.InventoryOn_OFF();
    }
    //======
    public void ShopOn_OFF(InputAction.CallbackContext context)
    {
        if (context.started)
            GameEventManager.instance.inputEvents.ShopOn_OFF();
    }
}