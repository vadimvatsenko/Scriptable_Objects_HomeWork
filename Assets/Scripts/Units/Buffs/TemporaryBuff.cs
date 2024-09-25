using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryBuff : IBuff
{
    private IBuffable _owner;
    private IBuff _coreBuff;
    private float _lifetime;
    private Timer _timer;

    public TemporaryBuff(IBuffable owner, IBuff buff, float lifetime)
    {
        _owner = owner;
        _coreBuff = buff;
        _lifetime = lifetime;

    }

    public CharacterStats ApplyBuff(CharacterStats stats)
    {
        CharacterStats newStats = _coreBuff.ApplyBuff(stats);
        _timer.StartTimer(_lifetime, () =>
        {
            _owner.RemoveBuff(this);
        });

        return newStats;
    }


}


