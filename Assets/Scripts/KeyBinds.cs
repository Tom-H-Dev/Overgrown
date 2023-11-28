using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Keybinds", menuName = "Keybinds")]
public class KeyBinds : ScriptableObject
{
    public KeyCode inventory;


    public KeyCode CheckKey(string key)
    {
        switch (key)
        {
            case "inventory":
                return inventory;

            default:
                return KeyCode.None;
        }
    }
}
