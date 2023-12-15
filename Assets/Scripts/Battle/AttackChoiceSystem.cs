using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackChoiceSystem : MonoBehaviour
{
    #region Singleton
    public static AttackChoiceSystem instance;
    private void Awake()
    {
        //if (instance != null)
        //    Destroy(instance);
        //else instance = this;
        instance = this;
    }
    #endregion
    public IPlayerClasses _player;

    public void BaseAttackChoice() => _player.BaseAttack();

    public void DefenseChoice() => _player.Defense();

    public void Level2AttackChoice() => _player.Level2Attack();

    public void Level4AttackChoice() => _player.Level4Attack();

    public void Level6AttackChoice() => _player.Level6Attack();
}
