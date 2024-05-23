using System;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager instance { get; private set; }

    public MiscEvents miscEvents;

    public QuestEvents questEvents;

    public InputEvents inputEvents;

    public PlayerEvents playerEvents;

    public GoldEvents goldEvents;

    private void Awake()
    {
        //GameEventManager.instance = this;
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in the scene.");
        }
        instance = this;
        miscEvents = new MiscEvents();
        questEvents = new QuestEvents();
        inputEvents = new InputEvents();
        playerEvents = new PlayerEvents();
        goldEvents = new GoldEvents();
    }

}
