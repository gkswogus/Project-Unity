using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;
using System.Collections;


public class TransitionItemDropRight : MonoBehaviour, IDropHandler
{

    [Header("��� �� ���")]
    [SerializeField] GameObject LeftSlot;

    [SerializeField] TMP_Text RightText;

    [SerializeField] GameObject MidleWindow;

    public GameObject[] T;

    public void OnDrop(PointerEventData eventData)
    {

        if (LeftSlot.transform.childCount != 0)
        {
            //�κ�â�� �����ϴ°�
            if (transform.childCount == 1)
            {
                TryswapItem();
            }
            else if (transform.childCount == 0)
            {
                ItemDrag.draggingItem.transform.SetParent(this.transform);
            }
        }
        else
        {
            print("�������"); //�׽�Ʈ
        }

        var Left = LeftSlot.transform.GetChild(0).gameObject.GetComponent<ItemUIObject>();
        var Right = this.transform.GetChild(0).gameObject.GetComponent<ItemUIObject>();

        if (LeftSlot.transform.GetChild(0).gameObject.tag == this.transform.GetChild(0).gameObject.tag)
        {
            if (Left.ItemLevel > Right.ItemLevel + 1)
            {
                if (Left.ITEM_RATING == ITEM_RATING.Normal && Right.ITEM_RATING == ITEM_RATING.Epic ||
                 Left.ITEM_RATING == ITEM_RATING.Epic && Right.ITEM_RATING == ITEM_RATING.Legend)
                {
                    var a = Right.itemname;
                    var b = Right.ItemLevel;
                    var c = Left.ItemLevel - 1;
                    RightText.text = string.Format("{0}+{1}({2})", a, b, c);
                }
                else RightText.text = string.Format("��� �Ұ�");
            }
            else RightText.text = string.Format("��� �Ұ�");
        }
        else RightText.text = string.Format("��� �Ұ�");

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
            RightText.text = string.Empty;
        }
    }

    void OnEnable()
    {
     
        T[0].SetActive(true);
        T[1].SetActive(false);
        T[2].SetActive(false);
        T[3].SetActive(false);
        T[4].SetActive(false);
    }
    void Start()
    {
        MidleWindow.SetActive(false);

    }

    IEnumerator midleWindowOnOff()
    {

        MidleWindow.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        SoundManager.instance.Play(UISOUND.Transition);
        T[1].SetActive(true);
        yield return new WaitForSeconds(0.4f);
        T[2].SetActive(true);
        yield return new WaitForSeconds(0.6f);
        T[3].SetActive(true);
        yield return new WaitForSeconds(0.8f);
        T[4].SetActive(true);
        yield return new WaitForSeconds(1.0f);
        MidleWindow.SetActive(false);
    }

    public void CheakItem() //��� ��ư Ŭ���� ����
    {
        var Left = LeftSlot.transform.GetChild(0).gameObject.GetComponent<ItemUIObject>();
        var Right = this.transform.GetChild(0).gameObject.GetComponent<ItemUIObject>();

        if (LeftSlot.transform.GetChild(0).gameObject.tag == this.transform.GetChild(0).gameObject.tag)
        {
            if (Left.ItemLevel > Right.ItemLevel + 1) //������ ���� ���̰� 2 �̻� ���� ��� ����
            {
                if (Left.ITEM_RATING == ITEM_RATING.Normal && Right.ITEM_RATING == ITEM_RATING.Epic || //���� ��ü�θ� ��� ���� 
                    Left.ITEM_RATING == ITEM_RATING.Epic && Right.ITEM_RATING == ITEM_RATING.Legend)
                {
                    StartCoroutine(midleWindowOnOff());

                    Debug.Log("��� ���� ����");
                    Destroy(LeftSlot.transform.GetChild(0).gameObject);
                    Right.ItemLevel = Left.ItemLevel - 1; //��� ���� ����� ������ ���� -1 ��ŭ ����                    
                
                  if(Right.ITEM_TYPE==ITEMTYPE.Shield && Right.ITEM_RATING==ITEM_RATING.Epic) Right.value += Right.ItemLevel * 10;
                  if (Right.ITEM_TYPE == ITEMTYPE.Weapon)
                    {
                        if(Right.ITEM_RATING==ITEM_RATING.Epic) Right.value += Right.ItemLevel * 50;
                        if(Right.ITEM_RATING==ITEM_RATING.Legend) Right.value += Right.ItemLevel * 60;
                    }
                    RightText.text = string.Format("{0}+{1}", Right.itemname, Left.ItemLevel - 1);
                }
            }
        }
    }
}