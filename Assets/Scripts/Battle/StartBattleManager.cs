using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBattleManager : MonoBehaviour
{
    [SerializeField] private GameObject _combatMenuStuff;

    [SerializeField] private GameObject _turnManager;
    [SerializeField] private GameObject _enemyBehavior;

    private void OnCollisionEnter(Collision collision)
    {
        GameManager.instance.canMovePlayer = false;
        _turnManager.SetActive(true);
        _enemyBehavior.SetActive(true);
        _combatMenuStuff.SetActive(true);
    }
}
