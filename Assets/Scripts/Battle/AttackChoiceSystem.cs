using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackChoiceSystem : MonoBehaviour
{
    private IPlayerClasses _player;
    private void Start()
    {
        _player = GetComponent<IPlayerClasses>();
    }

    public void BaseAttackChoice()
    {
        _player.BaseAttack();
    }
    public void DefenseChoice()
    {
        _player.Defense();
    }
    public void Level2AttackChoice()
    {
        _player.Level2Attack();
    }
    public void Level4AttackChoice()
    {
        _player.Level4Attack();
    }
    public void Level6AttackChoice()
    {
        _player.Level6Attack();
    }
}
