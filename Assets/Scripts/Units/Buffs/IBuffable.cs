using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuffable 
{
    public void AddBuff(IBuff buff);
    public void RemoveBuff(IBuff buff);
}
