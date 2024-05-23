using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class UpgradePoint : MonoBehaviour
{   
    Animator ani;
    [Header("장비 강화 창")]
    public GameObject UpgradeWindow;
    public GameObject TransitionWindow;
    public GameObject MidleWindow;
    bool ONOFF = false;
    public GameObject[] ItemText;
    [Header("강화 능력치")]
    public GameObject[] Stat;
    [Header("강화 골드")]
    public GameObject Mgold;
    [Header("강화 확률")]
    public GameObject Chance;
    //GameObject itemImp;
    [Header("아이템 레벨")]
    public GameObject ItemLevel;
    [Header("카메라 제어")]
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
    bool NearView() // 시야 체크
    {
        distance = Vector3.Distance(transform.position, player.transform.position); //거리 재기
        direction = transform.position - player.transform.position;// player과 몬스터의 사이값
        angleView = Vector3.Angle(player.transform.forward, direction); //바라보는 방향의 회전값 구하기
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
