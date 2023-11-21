using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensePotion : Potion
{
    private void Start()
    {
        p_potionName = "Defense Potion";
        potionType = "Defense";
        potionStatIncrease = 5;
        potionCard = gameObject;
        potionDescription = "Defense Potion: Temporarily boosts the drinker's resilience and reduces damage taken when consumed.";
    }

    public override void OnPotionUse()
    {
        base.OnPotionUse();
        InfoPageItem.instance.potionScript = this;
        PlayerBattleStats.instance.playerStats.defense += 5;
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
