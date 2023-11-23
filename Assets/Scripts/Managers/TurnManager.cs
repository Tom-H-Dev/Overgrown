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

    [Header("Player Battle UI")]
    [SerializeField] private GameObject _attackLevel1;
    [SerializeField] private GameObject _attackLevel2, _attackLevel4, _attackLevel6, _defense;

    [Header("Player")]
    [SerializeField] private GameObject _player;

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

    public void ChangeAttackListFromLevelUp()
    {
        //TODO: This function called when attack to check what attacks the player has unlocked
        PlayerClass l_player = _player.GetComponent<PlayerClass>();
        switch (l_player.playerLevel)
        {
            case 1:
                _attackLevel1.SetActive(true);
                _attackLevel2.SetActive(false);
                _attackLevel4.SetActive(false);
                _attackLevel6.SetActive(false);
                _defense.SetActive(true);
                break;
            case 2:
                _attackLevel1.SetActive(true);
                _attackLevel2.SetActive(true);
                _attackLevel4.SetActive(false);
                _attackLevel6.SetActive(false);
                _defense.SetActive(true);
                break;
            case 3:
                _attackLevel1.SetActive(true);
                _attackLevel2.SetActive(true);
                _attackLevel4.SetActive(false);
                _attackLevel6.SetActive(false);
                _defense.SetActive(true);
                break;
            case 4:
                _attackLevel1.SetActive(true);
                _attackLevel2.SetActive(true);
                _attackLevel4.SetActive(true);
                _attackLevel6.SetActive(false);
                _defense.SetActive(true);
                break;
            case 5:
                _attackLevel1.SetActive(true);
                _attackLevel2.SetActive(true);
                _attackLevel4.SetActive(true);
                _attackLevel6.SetActive(false);
                _defense.SetActive(true);
                break;
            case 6:
                _attackLevel1.SetActive(true);
                _attackLevel2.SetActive(true);
                _attackLevel4.SetActive(true);
                _attackLevel6.SetActive(true);
                _defense.SetActive(true);
                break;
            case >= 7:
                _attackLevel1.SetActive(true);
                _attackLevel2.SetActive(true);
                _attackLevel4.SetActive(true);
                _attackLevel6.SetActive(true);
                _defense.SetActive(true);
                break;
        }
    }
}

public enum PlayerTurns
{
    myturn,
    enemyturn
}