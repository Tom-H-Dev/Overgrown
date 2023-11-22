using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthPotion : Potion
{
    private void Start()
    {
        p_potionName = "Strength Potion";
        potionType = "Strength";
        potionStatIncrease = 5;
        potionCard = gameObject;
        potionDescription = "Strength Potion: Temporarily enhances physical strength and power when consumed.";
    }

    public override void OnPotionUse()
    {
        base.OnPotionUse();
        InfoPageItem.instance.potionScript = this;
        PlayerBattleStats.instance.playerStats.strength += 5;
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
