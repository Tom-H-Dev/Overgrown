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
    public HealthPotion healthPotion;
    public SpeedPotion speedPotion;
    public DefensePotion defensePotion;
    public StrengthPotion strengthPotion;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && !_isMenuActive)
        {
            _playerInventory.SetActive(true);
            GameManager.instance.ChangePlayerMovePermission(false);
            _isMenuActive = true;
            OnChangePotionAmount();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            AddInventoryItemManager.instance.potions = speedPotion;
            AddInventoryItemManager.instance.ChangePotionAmount(2);

            OnChangePotionAmount();
        }
    }

    public void ChangeMenuActive(bool l_value)
    {
        _isMenuActive = l_value;
    }

    public void OnChangePotionAmount()
    {
        foreach (GameObject l_inventoryPotions in inventoryPotions)
        {
            if (l_inventoryPotions.GetComponent<Potion>().potionAmount >= 1)
            {
                Potion l_potion = l_inventoryPotions.GetComponent<Potion>();
                l_potion.potionCard.SetActive(true);
                l_potion.potionAmountText.text = l_potion.potionAmount + "x";
            }
        }
    }
}
