using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsmanAttackFunctions : MonoBehaviour
{

    private int atkDmg = 2;

    public void Attack1()
    {
        Debug.Log("Attack1 Has been used!");
        GameObject foundObject = FindObjectById(GameManager.instance.selectedEnemy);
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

    public GameObject FindObjectById(int id)
    {
        foreach (GameObject obj in TurnManager.instance.currentActiveEnemies)
        {
            if (obj.GetComponent<EnemeyBehavior>().id == id)
            {
                return obj;
            }
        }

        return null;
    }

}
