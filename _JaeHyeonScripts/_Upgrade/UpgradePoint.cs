using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class UpgradePoint : MonoBehaviour
{   
    Animator ani;
    [Header("��� ��ȭ â")]
    public GameObject UpgradeWindow;
    public GameObject TransitionWindow;
    public GameObject MidleWindow;
    bool ONOFF = false;
    public GameObject[] ItemText;
    [Header("��ȭ �ɷ�ġ")]
    public GameObject[] Stat;
    [Header("��ȭ ���")]
    public GameObject Mgold;
    [Header("��ȭ Ȯ��")]
    public GameObject Chance;
    //GameObject itemImp;
    [Header("������ ����")]
    public GameObject ItemLevel;
    [Header("ī�޶� ����")]
  [SerializeField] private GameObject Cameras;
    public GameObject UpgradeCameras;
    bool CONOFF = true;
    bool UONOFF = false;

    Transform player;
    float distance;
    float angleView;
    Vector3 direction;

    AudioSource audioS;
    private void Awake()
    {
        ani = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        audioS = this.gameObject.GetComponent<AudioSource>();
    }
    private void Start()
    {
        Cameras.SetActive(CONOFF);
        UpgradeCameras.SetActive(UONOFF);
        UpgradeWindow.SetActive(ONOFF);
        MidleWindow.SetActive(false);
        for (int i = 0; i < ItemText.Length; i++)
        {
            ItemText[i].SetActive(false);
        }
        for (int i = 0; i < Stat.Length; i++)
        {
            Stat[i].SetActive(false);
        }
        Mgold.SetActive(false);
        Chance.SetActive(false);
        ItemLevel.SetActive(false);

        GameEventManager.instance.inputEvents.OnUpgradeWindow_On_Off += UpgradeWindow_On_Off;
    }
    bool NearView() // �þ� üũ
    {
        distance = Vector3.Distance(transform.position, player.transform.position); //�Ÿ� ���
        direction = transform.position - player.transform.position;// player�� ������ ���̰�
        angleView = Vector3.Angle(player.transform.forward, direction); //�ٶ󺸴� ������ ȸ���� ���ϱ�
        if (angleView < 45f && distance < 5f)
            return true;
        else return false;
    }
   
    private void OnDisable()
    {
        GameEventManager.instance.inputEvents.OnUpgradeWindow_On_Off -= UpgradeWindow_On_Off;
    }
    private void UpgradeWindow_On_Off()
    {
       if(!NearView())
        {          
           return;
        }

        if (Input.GetKeyUp(KeyCode.Y))
        SoundManager.instance.Play(GAMESOUND.Interaction, audioS);

        InventoryManager.instance.InventoryKey();
    
        
        ani.SetTrigger("isGreet");
        Cameras.SetActive((CONOFF)? false : true);
        CONOFF = CONOFF ? false : true;
        UpgradeCameras.SetActive((UONOFF)? false:true);
        UONOFF = UONOFF ? false : true;
        UpgradeWindow.gameObject.SetActive((ONOFF) ? false : true);
        ONOFF = ONOFF ? false : true;
       
        TransitionWindow.SetActive(false);

        for (int i = 0; i < ItemText.Length; i++)
        {
            ItemText[i].SetActive(false);
        }
        for (int i = 0; i < Stat.Length; i++)
        {
            Stat[i].SetActive(false);
        }
        Mgold.SetActive(false);
        Chance.SetActive(false);
        ItemLevel.SetActive(false);
    }

}
