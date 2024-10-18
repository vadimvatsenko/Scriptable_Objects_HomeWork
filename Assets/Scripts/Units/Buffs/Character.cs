using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : IBuffable
{
    public CharacterStats BaseStates { get; }
    public CharacterStats CurrentStats { get; private set; }
    private readonly List<IBuff> _buffs = new List<IBuff>();

    public Character(CharacterStats baseStats, CharacterStats currentStats)
    {
        BaseStates = baseStats;
        CurrentStats = currentStats;

        CurrentStats.CopyStats(baseStats);
    }
    public void AddBuff(IBuff buff)
    {
        _buffs.Add(buff);
        ApplyBuffs();
        Debug.Log($"Add {buff}");
    }

    public void RemoveBuff(IBuff buff)
    {
        _buffs.Remove(buff);
        ApplyBuffs();
        Debug.Log($"Remove {buff}");
    }

    private void ApplyBuffs()
    {
        CurrentStats.CopyStats(BaseStates);

        foreach (IBuff buff in _buffs)
        {
            buff.ApplyBuff(CurrentStats);
            Debug.Log("Apply Stats");
        }
    }
}
