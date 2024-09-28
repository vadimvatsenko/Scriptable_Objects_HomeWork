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

    public void ApplyBuff(CharacterStats stats)
    {
        CharacterStats newStats = stats;
        newStats.attackDamage = _damageBonus;
    }
}
