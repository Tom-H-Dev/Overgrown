using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerClassStats : ScriptableObject
{
    public float health;
    public float speed;
    public float strength;
    public float defense;

    public void CopyFrom(PlayerClassStats other)
    {
        var fields = typeof(PlayerClassStats).GetFields();
        foreach (var field in fields)
        {
            field.SetValue(this, field.GetValue(other));
        }
    }
}
