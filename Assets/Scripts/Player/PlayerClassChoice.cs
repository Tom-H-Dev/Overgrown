using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerClassChoice : MonoBehaviour
{
    #region singleton
    public static PlayerClassChoice instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject objectToAddScriptTo;
    [SerializeField] private Image _expProgressBar;
    public Animator animator;

    [Header("Player Stats")]
    public PlayerClassStats playerStats;
    [SerializeField] private PlayerClassStats _brawlerStats, _gunmanStats, _alchemistStats;



    private void Start()
    {
        GameManager.instance.ChangePlayerMovePermission(false);
        //Pop up to choose class
    }

    public void ClassChoice(string l_classScriptName)
    {
        GameManager.instance.ChangePlayerMovePermission(true);

        switch(l_classScriptName)
        {
            case "BrawlerClass":
                objectToAddScriptTo.AddComponent<BrawlerClass>();
                playerStats.CopyFrom(_brawlerStats);
                break;
            case "AlchemistClass":
                objectToAddScriptTo.AddComponent<AlchemistClass>();
                playerStats.CopyFrom(_alchemistStats);
                break;
            case "GunmanClass":
                objectToAddScriptTo.AddComponent<GunmanClass>();
                playerStats.CopyFrom(_gunmanStats);
                break;
        }

        AttackChoiceSystem.instance._player = objectToAddScriptTo.GetComponent<IPlayerClasses>();
        PlayerClass l_object = objectToAddScriptTo.GetComponent<PlayerClass>();
        l_object.expProgress = _expProgressBar;
        l_object.playerStats = playerStats;
    }
}
