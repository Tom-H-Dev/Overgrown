using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartBattleManager : MonoBehaviour
{
    [SerializeField] private GameObject _combatMenuStuff;

    [SerializeField] private GameObject _turnManager;
    [SerializeField] private GameObject _enemy1, _enemy2;
    [SerializeField] private Button _attackStartButton;

    [SerializeField] private Attack _attackScript;

    public bool hasEncountered = false;
    public bool finish = false;

    [Header("Enemy Type")]
    [SerializeField] private List<string> _enemyNames = new List<string>();
    [SerializeField] private List<EnemeyStats> _enemyStats = new List<EnemeyStats>();
    [SerializeField] private List<Sprite> _enemyVisuals = new List<Sprite>();


    [SerializeField] private EnemeyStats _enemyStat;
    private void OnTriggerEnter(Collider other)
    {
        int l_randomIndex = Random.Range(0, _enemyNames.Count);

        if (!hasEncountered)
        {
            GameManager.instance.canMovePlayer = false;

            _enemy1.SetActive(true);
            _enemy2.SetActive(true);
            _attackStartButton.interactable = true;


            _turnManager.SetActive(true);
            _attackScript.AttackButton();
            _combatMenuStuff.SetActive(true);

            for (int i = 0; i < TurnManager.instance.currentActiveEnemies.Count; i++)
            {
                TurnManager.instance.currentActiveEnemies[i].GetComponent<EnemyBehavior>().SetEnemyStatsVariable(_enemyStats[l_randomIndex]);
                TurnManager.instance.currentActiveEnemies[i].GetComponent<EnemyBehavior>()._enemySprite.sprite = _enemyVisuals[l_randomIndex];
                TurnManager.instance.currentActiveEnemies[i].GetComponent<EnemyBehavior>().ChangeHpFromOther(0);



                if (finish)
                {
                    TurnManager.instance.currentActiveEnemies[i].GetComponent<EnemyBehavior>().finish = finish;
                }
                PlayerBattleStats.instance.ChangeHpFromOther(0);
            }
            hasEncountered = true;
        }

        //Set All the enemies active that are in the combat by random amount of enemies
        //Reset the enemy stats
        //Set the enemy images
        //Update the player health bar
        //Set List of all enemies and player by speed value and sort
        //Turn from up to down and pass the current index and if the index above is nothing go to 0
    }
}
