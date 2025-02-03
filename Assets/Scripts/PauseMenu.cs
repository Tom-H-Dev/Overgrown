using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject _pausedCanvas;

    void Update()
    {
        if (Input.GetKey(InputManager.instance.keyBinds.CheckKey("pause")))
        {
            GameManager.instance.canMovePlayer = false;
            _pausedCanvas.SetActive(true);
        }
    }

    public void ContinueGame()
    {
        GameManager.instance.canMovePlayer = true;
        _pausedCanvas.SetActive(false);
    }
}
