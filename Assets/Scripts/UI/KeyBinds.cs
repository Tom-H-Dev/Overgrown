using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Keybinds", menuName = "Keybinds")]
public class KeyBinds : ScriptableObject
{
    public KeyCode inventory, sprint, interact, pause;

    /// <summary>
    /// To check which action key is bound to which key
    /// </summary>
    /// <param name="_key"></param> The key the certain action is bound to
    /// <returns></returns>
    public KeyCode CheckKey(string _key)
    {
        return _key switch
        {
            "inventory" => inventory,
            "sprint" => sprint,
            "interact" => interact,
            "pause" => pause,
            _ => KeyCode.None,
        };
    }

    /// <summary>
    /// Change the action to a new keybind
    /// </summary>
    /// <param name="_key"></param>
    /// <param name="_newKeyCode"></param> The key you want the action to be bound tp
    public void ChangeKey(string _key, KeyCode _newKeyCode)
    {
        switch (_key)
        {
            case "inventory":
                inventory = _newKeyCode;
                break;
            case "sprint":
                sprint = _newKeyCode;
                break;
            case "interact":
                interact = _newKeyCode;
                break;
            case "pause":
                pause = _newKeyCode;
                break;

            default:
                break;
        }
    }
}
