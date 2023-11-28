using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public KeyBinds keyBinds;

    #region Singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }
#endregion

    public bool KeyPressed(string key)
    {
        if (Input.GetKey(keyBinds.CheckKey(key)))
        {
            return true;
        }
        else { return false; }
    }

}
