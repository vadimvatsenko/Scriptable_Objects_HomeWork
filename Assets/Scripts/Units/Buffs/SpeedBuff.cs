using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff : IBuff
{
    private int _speedMulty;

    public SpeedBuff(int speedMulty)
    {
        _speedMulty = speedMulty;
    }

    public CharacterStats ApplyBuff(CharacterStats stats)
    {
        CharacterStats newStats = stats;
        newStats.speed = _speedMulty;

        return newStats;
    }
}
