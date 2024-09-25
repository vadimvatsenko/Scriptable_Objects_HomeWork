using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBuff : IBuff
{
    private int _damageBonus;
    public DamageBuff(int damageBonus)
    {
        _damageBonus = damageBonus;
    }

    public CharacterStats ApplyBuff(CharacterStats stats)
    {
        CharacterStats newStats = stats;
        newStats.attackDamage = _damageBonus;

        return newStats;
    }
}
