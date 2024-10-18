using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBuff : IBuff
{
    private int _addHealth;

    public HealthBuff(int addHealth)
    {
        _addHealth = addHealth;
    }

    public void ApplyBuff(CharacterStats stats)
    {
        CharacterStats newStats = stats;
        newStats.health = newStats.health + _addHealth < 100 ? newStats.health + _addHealth : 100;
    }
}
