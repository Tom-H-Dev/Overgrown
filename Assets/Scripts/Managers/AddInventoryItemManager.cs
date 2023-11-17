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
    [SerializeField] private SpeedPotion _speedPotion;
    [SerializeField] private StrengthPotion _strengthPotion;
    [SerializeField] private DefensePotion _defensePotion;

    public void ChangeHealthPotion(int l_value)
    {
        _healthPotion.ChangePotionAmount(l_value);
    }
    public void ChangeSpeedhPotion(int l_value)
    {
        _healthPotion.ChangePotionAmount(l_value);
    }
    public void ChangeStrengthPotion(int l_value)
    {
        _healthPotion.ChangePotionAmount(l_value);
    }
    public void ChangeDefensePotion(int l_value)
    {
        _healthPotion.ChangePotionAmount(l_value);
    }
}
