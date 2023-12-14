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
    public Image _enemySprite;
    [SerializeField] private GameObject _choiceButton;

    public bool finish = false;

    private void OnEnable()
    {
        TurnManager.instance.currentActiveEnemies.Add(gameObject);
        _choiceButton.SetActive(true);
    }

    public void SetEnemyStatsVariable(EnemeyStats l_stats)
    {
        stats = l_stats;
        SetBattleStats();
    }

    public void ChangeHpFromOther(float l_hpDifference)
    {
        float l_defenseRemove = stats.baseDEF;
        for (int i = 0; i < l_defenseRemove; i++)
        {
            l_hpDifference *= 0.9f;
            Debug.Log("Percentage = " + l_hpDifference);
        }

        if (l_hpDifference >= _curHP)
        { // dead
            TurnManager.instance.currentActiveEnemies.Remove(gameObject);
            gameObject.SetActive(false);

            if (TurnManager.instance.currentActiveEnemies.Count <= 0)
            {
                Debug.Log("You Won combat!");

                GameManager.instance.OnCombatComplete(finish);
            }
            _choiceButton.SetActive(false);
            Debug.Log("Enemy died");
        }
        else
        {
            _curHP -= l_hpDifference;
            _healthbar.rectTransform.sizeDelta = new Vector2((_curHP / stats.baseHP) * 200, 50);
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

    public void SetBattleStats()
    {
        _curHP = stats.baseHP;
        _curMP = stats.baseMP;
        _curATK = stats.baseATK;
        _curDEF = stats.baseDEF;
        _curSPD = stats.baseSPD;
    }
}
