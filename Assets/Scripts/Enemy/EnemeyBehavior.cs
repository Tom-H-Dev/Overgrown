using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemeyBehavior : MonoBehaviour
{
    [SerializeField] private EnemeyStats stats;
    public int id;
    [SerializeField] private float curHP, curMP, curATK, curDEF;

    [SerializeField] private GameObject _whatEnemyMenu;

    [SerializeField] private Image _healthbar;
    private int _healthbarPixelMultiplier = 40;

    private void Start()
    {
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
            gameObject.SetActive(false);

            if (TurnManager.instance.currentActiveEnemies.Count <= 0)
            {
                Debug.Log("You Won combat!");

                GameManager.instance.canMovePlayer = true;
                GameManager.instance.combatCanvas.SetActive(false);
            }

            Debug.Log("Enemy died");
        }
        else
        {
            curHP -= hpDifference;
            _healthbar.rectTransform.sizeDelta = new Vector2(curHP * _healthbarPixelMultiplier, 50);
        }
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
        PlayerBattleStats.instance.ChangeHpFromOther(curATK);
    }
}
