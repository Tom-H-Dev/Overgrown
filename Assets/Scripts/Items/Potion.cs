using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Potion : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] protected string p_potionName;
    public int potionAmount;
    protected int p_potionStatIncrease;
    public GameObject potionCard;
    public TextMeshProUGUI potionAmountText;


    protected virtual void OnPotionUse()
    {

    }

    public virtual void ChangePotionAmount(int l_increaseAmount)
    {
        potionAmount += l_increaseAmount;
    }

    public virtual void ItemClickEvent()
    {
        InfoPageItem.instance.itemTitle.text = p_potionName; 
    }

}
