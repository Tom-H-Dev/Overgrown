using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPotion : Potion
{
    private void Start()
    {
        p_potionName = "Speed Potion";
        potionType = "Speed";
        potionStatIncrease = 5;
        potionCard = gameObject;
        potionDescription = "Speed Potion: Grants a temporary burst of enhanced speed and agility when consumed.";
    }

    public override void OnPotionUse()
    {
        base.OnPotionUse();
        InfoPageItem.instance.potionScript = this;
        PlayerBattleStats.instance.playerStats.speed += 5;
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
