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

    public bool KeyPressed(string _key)
    {
        if (Input.GetKey(keyBinds.CheckKey(_key)))
        {
            return true;
        }
        else { return false; }
    }

    public void ChangeKeyBinding(string _key, KeyCode _newKeyCode)
    {
        keyBinds.ChangeKey(_key, _newKeyCode);
       
        //Playerprefs
    }
}
