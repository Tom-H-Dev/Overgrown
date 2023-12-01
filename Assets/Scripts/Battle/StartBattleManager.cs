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
    [SerializeField] private EnemeyStats _enemyStats;
    private void OnTriggerEnter(Collider other)
    {
        print("ello");
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
                TurnManager.instance.currentActiveEnemies[i].GetComponent<EnemyBehavior>().SetEnemyStatsVariable(_enemyStats);
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
