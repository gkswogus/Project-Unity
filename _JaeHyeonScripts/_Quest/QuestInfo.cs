using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestInfo", menuName = "ScriptableObject/QuestInfo",order =1)]  //����Ʈ ����
public class QuestInfo : ScriptableObject
{
 [field : SerializeField] public string id { get; private set; }

    [Header("General")]
    public string DisplayName;

    [Header("Requirements")] //����Ʈ ���� ����
    public int levelRequirement;
    public QuestInfo[] questPrerequistes;

    [Header("Steps")]
    public GameObject[] questStepPrefabs;

    [Header("Rewards")]
    public int goldReward;
    public int expReward;




    private void OnValidate() // ��ũ��Ʈ �Ǵ� �ν����� �󿡼� ������ ���� ����� �� ȣ��Ǵ� �Լ� 

         /*
       =>  Unity �����Ϳ��� �ν����Ϳ��� �� ��ũ��Ʈ �Ǵ� �ش� GameObject�� ���õ� ������ ������ ������ OnValidate �޼ҵ尡 ȣ��Ǿ� 
                                                 id ������ �ش� GameObject�� �̸����� �����ϰ� ��ũ��Ʈ�� ��� ��ü�� dirty�� ǥ���Ͽ� Unity�� ���� ������ �����ϵ��� ����
         */
    {
        #if UNITY_EDITOR
        id = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
        #endif
    }
}

