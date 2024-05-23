using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class TransitionItemDropLeft : MonoBehaviour, IDropHandler
{
    [SerializeField] TMP_Text LeftText;

    public void OnDrop(PointerEventData eventData)
    {
        //인벤창에 들어가게하는거
        if (transform.childCount == 1)
        {
            TryswapItem();
        }
        else if (transform.childCount == 0)
        {
            ItemDrag.draggingItem.transform.SetParent(this.transform);
        }

        var a = this.transform.GetChild(0).GetComponent<ItemUIObject>().itemname;
        var b = this.transform.GetChild(0).GetComponent<ItemUIObject>().ItemLevel;
        LeftText.text = string.Format("{0}+{1}", a, b);
           
    }
    public void TryswapItem()
    {
     

        if (ItemDrag.draggingItem != null)
        {
            ItemDrag.draggingItem.transform.SetParent(this.transform);
            transform.GetChild(0).SetParent(transform.GetChild(1).GetComponent<ItemDrag>().copyItemtr);
        }

    }
    private void Update()
    {
        if (this.transform.childCount == 0)
        {
            LeftText.text = string.Empty;
        }       
    }
}
