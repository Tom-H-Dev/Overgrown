using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.Examples.ObjectSpin;

public class SpeedPotion : Potion
{
    private void Start()
    {
        p_potionName = "Speed Potion";
        potionType = "Speed";
        potionStatIncrease = 5;
        potionCard = gameObject;
    }

    protected override void OnPotionUse()
    {
        base.OnPotionUse();
        
    }

    public override void ChangePotionAmount(int l_increaseAmount)
    {
        base.ChangePotionAmount(l_increaseAmount);
    }
}
