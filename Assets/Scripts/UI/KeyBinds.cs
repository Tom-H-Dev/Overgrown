using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Keybinds", menuName = "Keybinds")]
public class KeyBinds : ScriptableObject
{
    public KeyCode inventory, sprint;


    public KeyCode CheckKey(string key)
    {
        return key switch
        {
            "inventory" => inventory,
            "sprint" => sprint,
            _ => KeyCode.None,
        };
    }
}
