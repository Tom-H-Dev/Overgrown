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
        if(InputManager.instance.KeyPressed("inventory") && !_isMenuActive)
        {
            _playerInventory.SetActive(true);
            GameManager.instance.ChangePlayerMovePermission(false);
            _isMenuActive = true;
            OnChangePotionAmount();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            OnChangePotionAmount();
        }
    }

    public void ChangeMenuActive(bool l_value)
    {
        _isMenuActive = l_value;
    }

    public void OnChangePotionAmount()
    {
        for (int i = 0; i < inventoryPotions.Count; i++)
        {
            if (inventoryPotions[i].GetComponent<Potion>().potionAmount >= 1)
            {
                Potion l_potion = inventoryPotions[i].GetComponent<Potion>();
                l_potion.potionCard.SetActive(true);
                l_potion.potionAmountText.text = l_potion.potionAmount + "x";
            }
            else if (inventoryPotions[i].GetComponent<Potion>().potionAmount <= 0 && InfoPageItem.instance.potionScript == inventoryPotions[i].GetComponent<Potion>())
            {
                Potion l_potion = inventoryPotions[i].GetComponent<Potion>();
                l_potion.potionCard.SetActive(false);
                InfoPageItem.instance.gameObject.SetActive(false);
            }
        }
    }
}
