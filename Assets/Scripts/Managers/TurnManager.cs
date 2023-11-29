using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private GameObject attackLevel1;
    [SerializeField] private GameObject attackLevel2, attackLevel4, attackLevel6, defense;
    [Space]
    public Button battackLevel1;
    public Button battackLevel2, battackLevel4, battackLevel6, bdefense;

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

        battackLevel1 = attackLevel1.GetComponent<Button>();
        battackLevel2 = attackLevel2.GetComponent<Button>();
        battackLevel4 = attackLevel4.GetComponent<Button>();
        battackLevel6 = attackLevel6.GetComponent<Button>();
        bdefense = defense.GetComponent<Button>();
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

        PlayerClass l_player = _player.GetComponent<PlayerClass>();
        if (l_player.attack2OnCooldown)
        {
            l_player.turnsLeftToRecharge2--;
            if (l_player.turnsLeftToRecharge2 <= 0)
            {
                battackLevel2.interactable = true;
            }
        }
        else if (l_player.attack4OnCooldown)
        {
            l_player.turnsLeftToRecharge4--;
            if (l_player.turnsLeftToRecharge4 <= 0)
            {
                battackLevel4.interactable = true;
            }
        }
        else if (l_player.attack6OnCooldown)
        {
            l_player.turnsLeftToRecharge6--;
            if (l_player.turnsLeftToRecharge6 <= 0)
            {
                battackLevel6.interactable = true;
            }
        }



    }

    public void ChangeAttackListFromLevelUp()
    {
        //TODO: This function called when attack to check what attacks the player has unlocked
        PlayerClass l_player = _player.GetComponent<PlayerClass>();
        switch (l_player.playerLevel)
        {
            case 1:
                attackLevel1.SetActive(true);
                attackLevel2.SetActive(false);
                attackLevel4.SetActive(false);
                attackLevel6.SetActive(false);
                defense.SetActive(true);
                break;
            case 2:
                attackLevel1.SetActive(true);
                attackLevel2.SetActive(true);
                attackLevel4.SetActive(false);
                attackLevel6.SetActive(false);
                defense.SetActive(true);
                break;
            case 3:
                attackLevel1.SetActive(true);
                attackLevel2.SetActive(true);
                attackLevel4.SetActive(false);
                attackLevel6.SetActive(false);
                defense.SetActive(true);
                break;
            case 4:
                attackLevel1.SetActive(true);
                attackLevel2.SetActive(true);
                attackLevel4.SetActive(true);
                attackLevel6.SetActive(false);
                defense.SetActive(true);
                break;
            case 5:
                attackLevel1.SetActive(true);
                attackLevel2.SetActive(true);
                attackLevel4.SetActive(true);
                attackLevel6.SetActive(false);
                defense.SetActive(true);
                break;
            case 6:
                attackLevel1.SetActive(true);
                attackLevel2.SetActive(true);
                attackLevel4.SetActive(true);
                attackLevel6.SetActive(true);
                defense.SetActive(true);
                break;
            case >= 7:
                attackLevel1.SetActive(true);
                attackLevel2.SetActive(true);
                attackLevel4.SetActive(true);
                attackLevel6.SetActive(true);
                defense.SetActive(true);
                break;
        }
    }
}

public enum PlayerTurns
{
    myturn,
    enemyturn
}