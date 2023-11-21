using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SwordsmanAttackFunctions : MonoBehaviour
{

    private int atkDmg = 2;

    public void Attack1()
    {
        Debug.Log("Attack1 Has been used!");
        GameObject foundObject = GameManager.instance.FindObjectById(GameManager.instance.selectedEnemy);
        EnemeyBehavior enemybehavior = foundObject.GetComponent<EnemeyBehavior>();
        enemybehavior.ChangeHpFromOther(atkDmg);
        StartCoroutine(TurnManager.instance.NextTurn());

    }

    public void Attack2()
    {
        Debug.Log("Attack2 Has been used!");
    }

    public void Defense()
    {
        Debug.Log("Defense Has been used!");
    }
}
