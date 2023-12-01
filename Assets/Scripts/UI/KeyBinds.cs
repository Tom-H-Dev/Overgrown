using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Keybinds", menuName = "Keybinds")]
public class KeyBinds : ScriptableObject
{
    public KeyCode inventory, sprint;


    public KeyCode CheckKey(string key)
    {
        switch (key)
        {
            case "inventory":
                return inventory;

            case "sprint":
                return sprint;

            default:
                return KeyCode.None;
        }
    }
}
