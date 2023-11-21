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

    /// <summary>
    /// This is a function which adds a specific script based on the choice that the player make on what class the player wants to play
    /// </summary>
    /// <param name="l_scriptName"></This parameter is the name of the script that needs to be added to the player >
    private void PlayerCombatClassChoice(string l_scriptName)
    {
        MonoScript script = (MonoScript)Resources.Load(l_scriptName, typeof(MonoScript));
        if (script != null)
        {
            System.Type type = script.GetClass();
            if (type != null && objectToAddScriptTo.GetComponent(type) == null)
            {
                objectToAddScriptTo.AddComponent(type);
            }
        }
        else
        {
            Debug.LogError("Script " + l_scriptName + " not found in the Assets folder.");
        }
    }

    private void Start()
    {
        GameManager.instance.ChangePlayerMovePermission(false);
        //Pop up to choose class
    }

    public void ClassChoice(string l_classScriptName)
    {
        PlayerCombatClassChoice(l_classScriptName);
        GameManager.instance.ChangePlayerMovePermission(true);
        objectToAddScriptTo.GetComponent<PlayerClass>().expProgress = _expProgressBar;

    }
}
