using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        curHP = baseHP;
        curMP = baseMP;
    }

    public void ChangeHpFromOther(float hpDifference)
    {
        if (hpDifference >= curHP)//dead
        { 

        }
        else
        {
            curHP -= hpDifference;
        }
    }
}
