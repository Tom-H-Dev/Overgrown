using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Potion : MonoBehaviour
{
    [Header("Stats")]
    protected string p_potionName;
    public int potionAmount;
    protected int p_potionStatIncrease;
    public GameObject potionCard;


    protected virtual void OnPotionUse()
    {

    }

    public virtual void ChangePotionAmount(int l_increaseAmount)
    {
        potionAmount += l_increaseAmount;
    }

}
