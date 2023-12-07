using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Potion : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] protected string p_potionName;
    public int potionAmount;
    public int potionStatIncrease;
    protected string potionType;
    public GameObject potionCard;
    public TextMeshProUGUI potionAmountText;
    public string potionDescription;


    public virtual void OnPotionUse()
    {
        potionAmount--;
        PlayerInventory.instance.OnChangePotionAmount();
    }

    public virtual void ChangePotionAmount(int l_increaseAmount)
    {
        potionAmount += l_increaseAmount;
    }

    public virtual void ItemClickEvent()
    {
        InfoPageItem.instance.itemTitle.text = p_potionName; 
        InfoPageItem.instance.statIncreaseText.text = "+" + potionStatIncrease + " " + potionType;
        InfoPageItem.instance.itemDescription.text = potionDescription;
        InfoPageItem.instance.potionType = potionType;
        InfoPageItem.instance.potionScript = this;
    }

    public virtual void AddPotionToInv(float l_amount, Potion l_type)
    {
        AddInventoryItemManager.instance.potions = l_type;
        AddInventoryItemManager.instance.ChangePotionAmount(2);
    }

}
