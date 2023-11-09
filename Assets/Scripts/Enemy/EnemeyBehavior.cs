using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyBehavior : MonoBehaviour
{
    [SerializeField] private EnemeyStats stats;
    public int id;
    [SerializeField] private float curHP, curMP, curATK, curDEF;

    [SerializeField] private GameObject _whatEnemyMenu;

    private void Start()
    {
        stats.name = stats.name + "_" + id;
        curHP = stats.baseHP;
        curMP = stats.baseMP;
        curATK = stats.baseATK;
        curDEF = stats.baseDEF;

        TurnManager.instance.currentActiveEnemies.Add(gameObject);
    }

    public void ChangeHpFromOther(float hpDifference)
    {
        if (hpDifference >= curHP) 
        { // dead
            TurnManager.instance.currentActiveEnemies.Remove(gameObject);
            Debug.Log("Enemy died");
        }
        else curHP -= hpDifference;
    }

    public IEnumerator EnemyAttackRoutine()
    {
        yield return new WaitForSeconds(1);
        Attack();

        _whatEnemyMenu.SetActive(true);
        TurnManager.instance.turnText.text = "Your Turn!";
        TurnManager.instance.turns = PlayerTurns.myturn;

        yield return null;
    }



    public void Attack()
    {
        Debug.Log("Enemy used attack!");
    }
}
