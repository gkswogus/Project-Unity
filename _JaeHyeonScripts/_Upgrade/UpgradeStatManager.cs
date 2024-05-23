using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
public class UpgradeStatManager : MonoBehaviour, IDropHandler
{
    STD playerGold;
    public TMP_Text curStat;
    public TMP_Text nextStat;

    public TMP_Text curGold;
    public TMP_Text upgradGold;

    public TMP_Text Chance;
    int C; //��ȭ Ȯ��

    public TMP_Text ItemLevel;

    private int Mgold = 50;

    private int B = 10; //Ȯ�� ���� ��

    Animator ani;
    [Header("��ȭ ����Ʈ")]
    public GameObject[] UpgradeEffect;
    public Animation[] Effect;
    public void OnDrop(PointerEventData eventData)
    {

        ValueSwtich();

        ShieldStat();
        WeaponStat();
        ShoseStat();
        HatStat();

    }
    void ShieldStat()
    {
        if (GameObject.Find("��� �÷����� ����").transform.GetChild(0) != null)
        {
            if (GameObject.Find("��� �÷����� ����").transform.GetChild(0).CompareTag(Constant.Tag.Shield))
            {
                curStat.text = "���� �ɷ�ġ" + "\n\n" + "����   " + transform.GetChild(0).GetComponent<ItemUIObject>().value;

                if (transform.GetChild(0).GetComponent<ItemUIObject>().ITEM_RATING == ITEM_RATING.Normal) nextStat.text = "���� �ɷ�ġ" + "\n\n" + "        +5";
                if (transform.GetChild(0).GetComponent<ItemUIObject>().ITEM_RATING == ITEM_RATING.Epic) nextStat.text = "���� �ɷ�ġ" + "\n\n" + "        +10";

            }
        }
    }
    void WeaponStat()
    {
        if (GameObject.Find("��� �÷����� ����").transform.GetChild(0) != null)
        {
            if (GameObject.Find("��� �÷����� ����").transform.GetChild(0).CompareTag(Constant.Tag.Weapon))
            {
                curStat.text = "���� �ɷ�ġ" + "\n\n" + "���ݷ�  " + transform.GetChild(0).GetComponent<ItemUIObject>().value; // printValue;

                if (transform.GetChild(0).GetComponent<ItemUIObject>().ITEM_RATING == ITEM_RATING.Normal) nextStat.text = "���� �ɷ�ġ" + "\n\n" + "      +40";
                if (transform.GetChild(0).GetComponent<ItemUIObject>().ITEM_RATING == ITEM_RATING.Epic) nextStat.text = "���� �ɷ�ġ" + "\n\n" + "      +50";
                if (transform.GetChild(0).GetComponent<ItemUIObject>().ITEM_RATING == ITEM_RATING.Legend) nextStat.text = "���� �ɷ�ġ" + "\n\n" + "      +60";
            }
        }
    }
    void ShoseStat()
    {
        if (GameObject.Find("��� �÷����� ����").transform.GetChild(0) != null)
        {
            if (GameObject.Find("��� �÷����� ����").transform.GetChild(0).CompareTag(Constant.Tag.Shose))
            {
              
                curStat.text = "�Ź� �ɷ�ġ" + "\n\n" + "�̵��ӵ�  " + transform.GetChild(0).GetComponent<ItemUIObject>().value;
                nextStat.text = "���� �ɷ�ġ" + "\n\n" + "     +2";

            }
        }
    }
    void HatStat()
    {
        if (GameObject.Find("��� �÷����� ����").transform.GetChild(0) != null)
        {
            if (GameObject.Find("��� �÷����� ����").transform.GetChild(0).CompareTag(Constant.Tag.Hat))
            {
                int printValue = transform.GetChild(0).GetComponent<ItemUIObject>().value;
                curStat.text = "���� �ɷ�ġ" + "\n\n" + "����   " + printValue;
                nextStat.text = "���� �ɷ�ġ" + "\n\n" + "      +5";
            }
        }
    }


    private bool UPUP;
    IEnumerator Upgrade()
    {
        var IU = transform.GetChild(0).GetComponent<ItemUIObject>();
        if (UPUP)
            yield break;
        UPUP = true;
        if (IU.ItemLevel < 5 && playerGold.money >= Mgold)
        {
            ani.SetTrigger("upGrad");
            StartCoroutine(UgradeBtnsound());
        }
        yield return effectDly;

        UPUP = false;
        int A = Random.Range(0, B);

        if (GameObject.Find("��� �÷����� ����").transform.GetChild(0) != null)
        {
            if (IU.ItemLevel < 5 && playerGold.money >= Mgold)
            {

                playerGold.money -= Mgold;

                if (A == 1)
                {
                    StartCoroutine(ClearEffect());

                    if (GameObject.Find("��� �÷����� ����").transform.GetChild(0).CompareTag(Constant.Tag.Weapon))
                    {
                        if (IU.ITEM_RATING == ITEM_RATING.Normal)
                        {
                            if (IU.ItemLevel < 5)
                            {
                                IU.ItemLevel++;
                                IU.value += 40;
                            }

                            curStat.text = "���� �ɷ�ġ" + "\n\n" + "���ݷ�  " + IU.value;
                            nextStat.text = "���� �ɷ�ġ" + "\n\n" + "    +40";
                        }
                        if (IU.ITEM_RATING == ITEM_RATING.Epic)
                        {
                            if (IU.ItemLevel < 5)
                            {
                                IU.ItemLevel++;
                                IU.value += 50;
                            }

                            curStat.text = "���� �ɷ�ġ" + "\n\n" + "���ݷ�  " + transform.GetChild(0).GetComponent<ItemUIObject>().value;
                            nextStat.text = "���� �ɷ�ġ" + "\n\n" + "    +50";
                        }
                        if (IU.ITEM_RATING == ITEM_RATING.Legend)
                        {
                            if (IU.ItemLevel < 5)
                            {
                                IU.ItemLevel++;
                                IU.value += 60;
                            }

                            curStat.text = "���� �ɷ�ġ" + "\n\n" + "���ݷ�  " + IU.value;
                            nextStat.text = "���� �ɷ�ġ" + "\n\n" + "    +60";
                        }
                    }


                    if (GameObject.Find("��� �÷����� ����").transform.GetChild(0).CompareTag(Constant.Tag.Shield))
                    {
                        if (IU.ITEM_RATING == ITEM_RATING.Normal)
                        {
                            {
                                if (IU.ItemLevel < 5)
                                {
                                    IU.ItemLevel++;
                                    IU.value += 5;
                                }
                                curStat.text = "���� �ɷ�ġ" + "\n\n" + "����  " + IU.value;
                                nextStat.text = "���� �ɷ�ġ" + "\n\n" + "    +5";
                            }
                        }
                        if (IU.ITEM_RATING == ITEM_RATING.Epic)
                        {
                            {
                                if (IU.ItemLevel < 5)
                                {
                                    IU.ItemLevel++;
                                    IU.value += 10;
                                }
                                curStat.text = "���� �ɷ�ġ" + "\n\n" + "����  " + IU.value;
                                nextStat.text = "���� �ɷ�ġ" + "\n\n" + "    +10";
                            }
                        }

                    }


                    if (GameObject.Find("��� �÷����� ����").transform.GetChild(0).CompareTag(Constant.Tag.Shose))
                    {
                        
                        if (IU.ItemLevel < 5)
                        {
                            IU.ItemLevel++;
                            IU.value += 2;
                        }
                        curStat.text = "�Ź� �ɷ�ġ" + "\n\n" + "�̵��ӵ�  " + IU.value;
                        nextStat.text = "���� �ɷ�ġ" + "\n\n" + "    +2";
                    }


                    if (GameObject.Find("��� �÷����� ����").transform.GetChild(0).CompareTag(Constant.Tag.Hat))
                    {
                        
                        if (IU.ItemLevel < 5)
                        {
                            IU.ItemLevel++;
                            IU.value += 5;
                        }
                        curStat.text = "���� �ɷ�ġ" + "\n\n" + "����  " + IU.value;
                        nextStat.text = "���� �ɷ�ġ" + "\n\n" + "    +5";
                    }

                }
                else StartCoroutine(FillEffect());
            }
        }
        ValueSwtich();
    }
    public void UpgradeBtn()
    {
    
        if (this.transform.childCount != 0)
            StartCoroutine(Upgrade());
    }
    IEnumerator UgradeBtnsound()
    {
        SoundManager.instance.Play(UISOUND.UpgradeBtn);
        yield return new WaitForSeconds(1.0f);
        SoundManager.instance.Play(UISOUND.UpgradeBtn);
    }
    void Awake()
    {
        playerGold = GameObject.FindWithTag("Player").GetComponent<STD>();
        UpgradeEffect[0].SetActive(false);
        UpgradeEffect[1].SetActive(false);

        ani = GameObject.Find("NPC(�������� ��)").GetComponent<Animator>();
    }

    void Update()
    {
        curGold.text = string.Format("���� ��� : " + "{0}", playerGold.money);
        upgradGold.text = string.Format("�Ҹ� ��� : " + "{0}", Mgold);
        Chance.text = string.Format("��ȭ Ȯ�� : " + C + "%");

        if (this.transform.childCount == 0)
        {
            curStat.text = string.Empty;
            nextStat.text = string.Empty;
            upgradGold.text = string.Empty;
            Chance.text = string.Empty;
            ItemLevel.text = string.Empty;
        }
    }
    private WaitForSeconds effectDly = new WaitForSeconds(2.2f);
    IEnumerator ClearEffect()
    {
        UpgradeEffect[0].SetActive(true);
        Effect[0].Play();
        SoundManager.instance.Play(UISOUND.UpgradeO);
        yield return effectDly;
        UpgradeEffect[0].SetActive(false);
    }
    IEnumerator FillEffect()
    {
        UpgradeEffect[1].SetActive(true);
        Effect[1].Play();
        SoundManager.instance.Play(UISOUND.UpgradeX);
        yield return effectDly;
        UpgradeEffect[1].SetActive(false);
    }


    void ValueSwtich()
    {
       
        if(transform.GetChild(0).GetComponent<ItemUIObject>().ITEM_RATING==ITEM_RATING.Epic)
        {
            switch (transform.GetChild(0).GetComponent<ItemUIObject>().ItemLevel)
            {
                case 0:
                    Mgold = 100;
                    B = 2;
                    C = 50;
                    ItemLevel.text = string.Format(" + 0");
                    break;
                case 1:
                    Mgold = 125;
                    B = 3;
                    C = 33;
                    ItemLevel.text = string.Format(" + 1");
                    break;
                case 2:
                    Mgold = 150;
                    B = 4;
                    C = 25;
                    ItemLevel.text = string.Format(" + 2");
                    break;
                case 3:
                    Mgold = 180;
                    B = 5;
                    C = 20;
                    ItemLevel.text = string.Format(" + 3");
                    break;
                case 4:
                    Mgold = 250;
                    B = 6;
                    C = 16;
                    ItemLevel.text = string.Format(" + 4");
                    break;
                case 5:
                    Mgold = 0;
                    B = 7;
                    C = 0;
                    ItemLevel.text = string.Format(" + MAX");
                    break;
            }
        }
  
       else if (transform.GetChild(0).GetComponent<ItemUIObject>().ITEM_RATING == ITEM_RATING.Legend)
        {
            switch (transform.GetChild(0).GetComponent<ItemUIObject>().ItemLevel)
            {
                case 0:
                    Mgold = 500;
                    B = 2;
                    C = 50;
                    ItemLevel.text = string.Format(" + 0");
                    break;
                case 1:
                    Mgold = 600;
                    B = 3;
                    C = 33;
                    ItemLevel.text = string.Format(" + 1");
                    break;
                case 2:
                    Mgold = 700;
                    B = 4;
                    C = 25;
                    ItemLevel.text = string.Format(" + 2");
                    break;
                case 3:
                    Mgold = 800;
                    B = 5;
                    C = 20;
                    ItemLevel.text = string.Format(" + 3");
                    break;
                case 4:
                    Mgold = 950;
                    B = 6;
                    C = 16;
                    ItemLevel.text = string.Format(" + 4");
                    break;
                case 5:
                    Mgold = 1200;
                    B = 7;
                    C = 0;
                    ItemLevel.text = string.Format(" + MAX");
                    break;
            }
        }
        else
        {
            switch (transform.GetChild(0).GetComponent<ItemUIObject>().ItemLevel)
            {
                case 0:
                    Mgold = 50;
                    B = 2;
                    C = 50;
                    ItemLevel.text = string.Format(" + 0");
                    break;
                case 1:
                    Mgold = 65;
                    B = 3;
                    C = 33;
                    ItemLevel.text = string.Format(" + 1");
                    break;
                case 2:
                    Mgold = 80;
                    B = 4;
                    C = 25;
                    ItemLevel.text = string.Format(" + 2");
                    break;
                case 3:
                    Mgold = 100;
                    B = 5;
                    C = 20;
                    ItemLevel.text = string.Format(" + 3");
                    break;
                case 4:
                    Mgold = 150;
                    B = 6;
                    C = 16;
                    ItemLevel.text = string.Format(" + 4");
                    break;
                case 5:
                    Mgold = 0;
                    B = 7;
                    C = 0;
                    ItemLevel.text = string.Format(" + MAX");
                    break;
            }
        }
    }
}