using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunmanClass : PlayerClass, IPlayerClasses
{

    public void BaseAttack()
    {
        Debug.Log("Attack1 Has been used!");
        GameObject foundObject = GameManager.instance.FindObjectById(GameManager.instance.selectedEnemy);
        EnemyBehavior enemybehavior = foundObject.GetComponent<EnemyBehavior>();
        enemybehavior.ChangeHpFromOther(PlayerBattleStats.instance.playerStats.strength);
        StartCoroutine(TurnManager.instance.NextTurn());
    }

    public void Defense()
    {

    }
    public void Level2Attack()
    {

    }
    public void Level4Attack()
    {

    }
    public void Level6Attack()
    {

    }
}
