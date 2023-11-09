using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBattleManager : MonoBehaviour
{
    [SerializeField] private GameObject _combatMenuStuff;
    private void OnCollisionEnter(Collision collision)
    {
        GameManager.instance.canMovePlayer = false;
        _combatMenuStuff.SetActive(true);
    }
}
