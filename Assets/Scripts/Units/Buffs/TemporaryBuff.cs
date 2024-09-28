using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TemporaryBuff : IBuff
{
    private IBuffable _owner;
    private IBuff _coreBuff;
    private float _lifetime;
    private Timer _timer;

    public TemporaryBuff(IBuffable owner, IBuff buff, int lifetime)
    {
        _owner = owner;
        _coreBuff = buff;
        _lifetime = lifetime;
        _timer = new Timer();
    }

    public void ApplyBuff(CharacterStats stats)
    {
        _coreBuff.ApplyBuff(stats);
       
        _ = _timer.RunTimer((int)_lifetime, () =>
        {
            _owner.RemoveBuff(this);
        });
    }
}


