using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    #region Singleton
    public static TurnManager instance;
    private void Awake()
    {

        if (instance != null)
            Destroy(instance);
        else instance = this;
    }
    #endregion

    public PlayerTurns turns = PlayerTurns.myturn;
    public TextMeshProUGUI turnText;
    public List<GameObject> currentActiveEnemies = new List<GameObject>();
    [SerializeField] private GameObject _attackChooseMenu;

    private PlayerBattleStats _battleStats;
    private EnemyBehavior _enemyBehavior;

    private void Start()
    {
        _battleStats = FindObjectOfType<PlayerBattleStats>();
        _enemyBehavior = FindObjectOfType<EnemyBehavior>();

        if (_battleStats.curSPD >= _enemyBehavior._curSPD)
        {
            turns = PlayerTurns.myturn;
        }
        else
        {
            turns = PlayerTurns.enemyturn;
            StartCoroutine(_enemyBehavior.EnemyAttackRoutine()); 
        }        
    }

    private void Update()
    {
        turnText.text = turns.ToString();
    }

    public IEnumerator NextTurn()
    {
        GameManager.instance.selectedEnemy = 0;
        GameManager.instance.hasBeenSelectedEnemy = false;

        turns = PlayerTurns.enemyturn;

        yield return null;
        for (int i = 0; i < currentActiveEnemies.Count; i++)
        {
            StartCoroutine(currentActiveEnemies[i].GetComponent<EnemyBehavior>().EnemyAttackRoutine());
        }
    }
}

public enum PlayerTurns
{
    myturn,
    enemyturn
}