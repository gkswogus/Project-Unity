using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class UpgradeItemDrop : MonoBehaviour, IDropHandler
{
    public GameObject UpgradeNPC;
    [Header("무기 방패 텍스트 변환")]
    [SerializeField] TMP_Text WeponTxt;
    [SerializeField] TMP_Text shieldTxt;
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
        UpgradeShield();
        UpgradeHat();
        UpgradeWepon();
        UpgradeShose();
        UpgradeStat();
    }
    void UpgradeShield()
    {
        if (gameObject.transform.childCount != 0)
        {

            switch (gameObject.transform.GetChild(0).GetComponent<ItemUIObject>().ITEM_TYPE)
            {
                case ITEMTYPE.Shield:
                    if(gameObject.transform.GetChild(0).GetComponent<ItemUIObject>().ITEM_RATING==ITEM_RATING.Normal)
                    shieldTxt.text = string.Format("낡은 방패");
                    if (gameObject.transform.GetChild(0).GetComponent<ItemUIObject>().ITEM_RATING == ITEM_RATING.Epic)
                        shieldTxt.text = string.Format("왕의 방패");
                    UpgradeNPC.GetComponent<UpgradePoint>().ItemText[2].SetActive(true);
                    break;


                default:
                    UpgradeNPC.GetComponent<UpgradePoint>().ItemText[2].SetActive(false);
                    break;
            }
        }

    }
    void UpgradeWepon()
    {
        if (gameObject.transform.childCount != 0)
        {
            switch (gameObject.transform.GetChild(0).GetComponent<ItemUIObject>().ITEM_TYPE)
            {
                case ITEMTYPE.Weapon:
                    if (gameObject.transform.GetChild(0).GetComponent<ItemUIObject>().ITEM_RATING == ITEM_RATING.Normal)
                        WeponTxt.text = string.Format("낡은 무기");
                    if (gameObject.transform.GetChild(0).GetComponent<ItemUIObject>().ITEM_RATING == ITEM_RATING.Epic)
                        WeponTxt.text = string.Format("쓸만한 무기");
                    if (gameObject.transform.GetChild(0).GetComponent<ItemUIObject>().ITEM_RATING == ITEM_RATING.Legend)
                        WeponTxt.text = string.Format("왕의 무기");

                    UpgradeNPC.GetComponent<UpgradePoint>().ItemText[0].SetActive(true);
                    break;


                default:
                    UpgradeNPC.GetComponent<UpgradePoint>().ItemText[0].SetActive(false);
                    break;
            }
        }
    }
    void UpgradeHat()
    {
        if (gameObject.transform.childCount != 0)
        {
            if (gameObject.transform.GetChild(0).tag == ("Hat"))
            {
                UpgradeNPC.GetComponent<UpgradePoint>().ItemText[1].SetActive(true);
            }
            else
            {
                UpgradeNPC.GetComponent<UpgradePoint>().ItemText[1].SetActive(false);
            }
        }
    }
    void UpgradeShose()
    {

        if (gameObject.transform.childCount != 0)
        {
            if (gameObject.transform.GetChild(0).tag == ("Shose"))
            {
                UpgradeNPC.GetComponent<UpgradePoint>().ItemText[3].SetActive(true);
            }
            else
            {
                UpgradeNPC.GetComponent<UpgradePoint>().ItemText[3].SetActive(false);
            }
        }
    }
    void UpgradeStat()
    {
        if (gameObject.transform.childCount != 0)
        {
            for (int i = 0; i < UpgradeNPC.GetComponent<UpgradePoint>().Stat.Length; i++)
            {
                UpgradeNPC.GetComponent<UpgradePoint>().Stat[i].SetActive(true);
            }
            UpgradeNPC.GetComponent<UpgradePoint>().Mgold.SetActive(true);
            UpgradeNPC.GetComponent<UpgradePoint>().Chance.SetActive(true);
            UpgradeNPC.GetComponent<UpgradePoint>().ItemLevel.SetActive(true);
        }

    }
    public void TryswapItem()
    {
        // ItemMerge();

        if (ItemDrag.draggingItem != null)
        {
            ItemDrag.draggingItem.transform.SetParent(this.transform);
            transform.GetChild(0).SetParent(transform.GetChild(1).GetComponent<ItemDrag>().copyItemtr);
        }

    }
    void Update()
    {
        if (transform.childCount == 0)
        {
            for (int i = 0; i < UpgradeNPC.GetComponent<UpgradePoint>().ItemText.Length; i++)
                UpgradeNPC.GetComponent<UpgradePoint>().ItemText[i].SetActive(false);
        }
    }
}