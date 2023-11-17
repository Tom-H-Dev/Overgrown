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
    [SerializeField] private HealthPotion _healthPotion;

    public void ChangeHealthPotion(int l_value)
    {
        _healthPotion.ChangePotionAmount(l_value);
    }
}
