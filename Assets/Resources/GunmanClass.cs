using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
        Debug.Log("Attack2 Has been used!");
        foreach (GameObject l_foudObjects in TurnManager.instance.currentActiveEnemies)
        {
            EnemyBehavior enemybehavior = l_foudObjects.GetComponent<EnemyBehavior>();
            enemybehavior.ChangeHpFromOther(PlayerBattleStats.instance.playerStats.strength - 2);
        }
        attack2OnCooldown = true;
        turnsLeftToRecharge2 = rechargeTime2 + 1;
        TurnManager.instance.battackLevel2.interactable = false;
        StartCoroutine(TurnManager.instance.NextTurn());
    }
    public void Level4Attack()
    {
        Debug.Log("Attack4 Has been used!");
        GameObject foundObject = GameManager.instance.FindObjectById(GameManager.instance.selectedEnemy);
        EnemyBehavior enemybehavior = foundObject.GetComponent<EnemyBehavior>();
        enemybehavior.ChangeHpFromOther(PlayerBattleStats.instance.playerStats.strength * 2);
        attack4OnCooldown = true;
        turnsLeftToRecharge2 = rechargeTime4 + 1;
        TurnManager.instance.battackLevel4.interactable = false;
        StartCoroutine(TurnManager.instance.NextTurn());
    }
    public void Level6Attack()
    {

    }
}
