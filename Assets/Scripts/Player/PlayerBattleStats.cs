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
        float l_checkIfHealing = curHP - l_hpDifference;

        if (l_hpDifference >= curHP) //dead
        {
            Debug.Log("YOU DIED!!! :(:(:(:(:(:(");
            curHP = 0;
        }
        else if (l_hpDifference == 0 || l_checkIfHealing >= playerStats.health)
        {
            Debug.Log("Max Health");
            curHP = playerStats.health;
            _healthbar.rectTransform.sizeDelta = new Vector2((curHP / playerStats.health) * 300, 50);
        }
        else
        {
            curHP -= l_hpDifference;
            _healthbar.rectTransform.sizeDelta = new Vector2((curHP / playerStats.health) * 300, 50);
        }
    }
}
