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

    private float _baseMP = 10;

    public float curHP;
    public float curMP;
    public float curSPD;

    [SerializeField] private Image _healthbar;
    private int _healthbarPixelMultiplier = 30;

    public PlayerClassStats playerStats;

    private void Start()
    {
        curHP = playerStats.health;
        curMP = _baseMP;
        curSPD = playerStats.speed;
    }

    public void ChangeHpFromOther(float l_hpDifference)
    {
        if (l_hpDifference >= curHP) //dead
        {
            Debug.Log("YOU DIED!!! :(:(:(:(:(:(");
            curHP = 0;
        }
        else
        {
            curHP -= l_hpDifference;
            Debug.Log("Base = " + playerStats.health);
            Debug.Log("%% " + (curHP / playerStats.health) * 100);
            _healthbar.rectTransform.sizeDelta = new Vector2(((curHP / playerStats.health) * 100) * 3, 50);
        }
    }
}
