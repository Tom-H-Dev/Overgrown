using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
                playerStats.health = _brawlerStats.health;
                playerStats.speed = _brawlerStats.speed;
                playerStats.strength = _brawlerStats.strength;
                playerStats.defense = _brawlerStats.defense;
                break;
            case "AlchemistClass":
                objectToAddScriptTo.AddComponent<AlchemistClass>();
                playerStats.health = _alchemistStats.health;
                playerStats.speed = _alchemistStats.speed;
                playerStats.strength = _alchemistStats.strength;
                playerStats.defense = _alchemistStats.defense;
                break;
            case "GunmanClass":
                objectToAddScriptTo.AddComponent<GunmanClass>();
                playerStats.health = _gunmanStats.health;
                playerStats.speed = _gunmanStats.speed;
                playerStats.strength = _gunmanStats.strength;
                playerStats.defense = _gunmanStats.defense;
                break;
        }

        AttackChoiceSystem.instance._player = objectToAddScriptTo.GetComponent<IPlayerClasses>();
        PlayerClass l_object = objectToAddScriptTo.GetComponent<PlayerClass>();
        l_object.expProgress = _expProgressBar;
        l_object.playerStats = playerStats;
    }
}
