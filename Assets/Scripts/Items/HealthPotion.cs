using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Potion
{
    private void Start()
    {
        p_potionName = "Health Potion";
        potionType = "Health";
        potionStatIncrease = 5;
        potionCard = gameObject;
        potionDescription = "Health Potion: Restores health and vitality when consumed.";
    }

    public override void OnPotionUse()
    {
        base.OnPotionUse();
        PlayerBattleStats.instance.ChangeHpFromOther(-potionStatIncrease);
    }

    public override void ChangePotionAmount(int l_increaseAmount)
    {
        base.ChangePotionAmount(l_increaseAmount);
    }
    public override void ItemClickEvent()
    {
        base.ItemClickEvent();
    }
}
