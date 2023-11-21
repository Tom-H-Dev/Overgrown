using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddInventoryItemManager : MonoBehaviour
{
    #region singleton
    public static AddInventoryItemManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    [Header("Inventory Item Scripts")]
    public Potion potions;

    public void ChangePotionAmount(int l_value)
    {
        potions.ChangePotionAmount(l_value);
        PlayerInventory.instance.OnChangePotionAmount();
    }
}
