using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject _pausedCanvas;

    void Update()
    {
        if (FindAnyObjectByType<StartBattleManager>().finish)
        {
            GameManager.instance.canMovePlayer = false;
            _pausedCanvas.SetActive(true);
        }
    }

    public void ContinueGame()
    {
        _pausedCanvas.SetActive(false);
        GameManager.instance.canMovePlayer = true;
    }
}
