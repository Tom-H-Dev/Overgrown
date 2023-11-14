using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleStats : MonoBehaviour
{
    #region Singleton
    public static PlayerBattleStats instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    private float baseHP = 10;
    private float baseMP = 10;

    public float curHP;
    public float curMP;

    [SerializeField] private Image _healthbar;
    private int _healthbarPixelMultiplier = 30;

    private void Start()
    {
        curHP = baseHP;
        curMP = baseMP;
    }

    public void ChangeHpFromOther(float hpDifference)
    {
        if (hpDifference >= curHP)//dead
        {
            Debug.Log("YOU DIED!!! :(:(:(:(:(:(");
            curHP = 0;
        }
        else
        {
            curHP -= hpDifference;
            _healthbar.rectTransform.sizeDelta = new Vector2(curHP * _healthbarPixelMultiplier, 50);
        }
    }
}
