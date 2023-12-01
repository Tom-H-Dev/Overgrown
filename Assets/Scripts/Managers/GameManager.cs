using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        //if (instance != null)
        //    Destroy(instance);
        //else instance = this;
        instance = this;
    }
    #endregion

    public bool canMovePlayer = true;
    public bool hasBeenSelectedEnemy = false;
    public int selectedEnemy = 0;
    [SerializeField] public GameObject combatCanvas;

    public bool inInteractionArea = false;

    public void ChangePlayerMovePermission(bool l_value)
    {
        canMovePlayer = l_value;
    }

    public GameObject FindObjectById(int id)
    {
        foreach (GameObject obj in TurnManager.instance.currentActiveEnemies)
        {
            if (obj.GetComponent<EnemyBehavior>().id == id)
            {
                return obj;
            }
        }

        return null;
    }

    public void OnCombatComplete(bool l_inFinish)
    {
        if (l_inFinish)
        {
            Debug.Log("Finish");
        }
        else
        {
            canMovePlayer = true;
            combatCanvas.SetActive(false);
            TurnManager.instance.gameObject.SetActive(false);

            PlayerClass l_player = FindObjectOfType<PlayerClass>();
            l_player.ChangePlayerExp(70);
            AddInventoryItemManager.instance.potions = PlayerInventory.instance.healthPotion;
            AddInventoryItemManager.instance.ChangePotionAmount(2);
        }
    }
}
