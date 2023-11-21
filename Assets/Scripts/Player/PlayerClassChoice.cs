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

    private void Start()
    {
        GameManager.instance.ChangePlayerMovePermission(false);
        //Pop up to choose class
    }

    public void ClassChoice(string l_classScriptName)
    {
        GameManager.instance.ChangePlayerMovePermission(true);
        objectToAddScriptTo.GetComponent<PlayerClass>().expProgress = _expProgressBar;

        switch(l_classScriptName)
        {
            case "BrawlerClass":
                objectToAddScriptTo.AddComponent<BrawlerClass>();
                break;
            case "AlchemistClass":
                objectToAddScriptTo.AddComponent<AlchemistClass>();
                break;
            case "GunmanClass":
                objectToAddScriptTo.AddComponent<GunmanClass>();
                break;
        }

    }
}
