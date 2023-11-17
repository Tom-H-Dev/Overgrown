using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthPotion : Potion
{
    private void Start()
    {
        p_potionName = "Strength Potion";
        p_potionStatIncrease = 5;
        potionCard = gameObject;
    }

    protected override void OnPotionUse()
    {
        base.OnPotionUse();
        PlayerBattleStats.instance.ChangeHpFromOther(-p_potionStatIncrease);
    }

    public override void ChangePotionAmount(int l_increaseAmount)
    {
        base.ChangePotionAmount(l_increaseAmount);
    }
}
