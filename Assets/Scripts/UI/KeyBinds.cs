using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Keybinds", menuName = "Keybinds")]
public class KeyBinds : ScriptableObject
{
    public KeyCode inventory, sprint, interact;

    public KeyCode CheckKey(string _key)
    {
        return _key switch
        {
            "inventory" => inventory,
            "sprint" => sprint,
            "interact" => interact,
            _ => KeyCode.None,
        };
    }

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
            default:
                break;
        }
    }
}
