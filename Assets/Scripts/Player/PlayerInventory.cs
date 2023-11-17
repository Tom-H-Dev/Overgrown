using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    #region singleton
    public static PlayerInventory instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public List<GameObject> inventoryPotions = new List<GameObject>();

    [SerializeField] private GameObject _playerInventory;
    private bool _isMenuActive = false;
    [SerializeField] HealthPotion healthPotion;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && !_isMenuActive)
        {
            _playerInventory.SetActive(true);
            GameManager.instance.ChangePlayerMovePermission(false);
            _isMenuActive = true;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            AddInventoryItemManager.instance.ChangeHealthPotion(2);

            OnChangePotionAmount();
        }
    }

    public void ChangeMenuActive(bool l_value)
    {
        _isMenuActive = l_value;
    }

    public void OnChangePotionAmount()
    {
        foreach (GameObject potions in inventoryPotions)
        {
            if (potions.GetComponent<Potion>().potionAmount >= 1)
            {
                potions.GetComponent<Potion>().potionCard.SetActive(true);
            }
        }
    }
}
