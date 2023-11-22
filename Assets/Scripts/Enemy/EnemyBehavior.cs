using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private EnemeyStats stats;
    [SerializeField] private GameObject _turnManager;
    public int id;
    [SerializeField] public float _curHP, _curMP, _curATK, _curDEF, _curSPD;

    [SerializeField] private GameObject _whatEnemyMenu;

    [SerializeField] private Image _healthbar;
    private int _healthbarPixelMultiplier = 40;

    private void OnEnable()
    {
        _curHP = stats.baseHP;
        _curMP = stats.baseMP;
        _curATK = stats.baseATK;
        _curDEF = stats.baseDEF;
        _curSPD = stats.baseSPD;

        TurnManager.instance.currentActiveEnemies.Add(gameObject);
    }

    public void ChangeHpFromOther(float hpDifference)
    {
        if (hpDifference >= _curHP)
        { // dead
            TurnManager.instance.currentActiveEnemies.Remove(gameObject);
            gameObject.SetActive(false);

            if (TurnManager.instance.currentActiveEnemies.Count <= 0)
            {
                Debug.Log("You Won combat!");

                GameManager.instance.OnCombatComplete();
            }

            Debug.Log("Enemy died");
        }
        else
        {
            _curHP -= hpDifference;
            _healthbar.rectTransform.sizeDelta = new Vector2(_curHP * _healthbarPixelMultiplier, 50);
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
        PlayerBattleStats.instance.ChangeHpFromOther(_curATK);
    }
}
