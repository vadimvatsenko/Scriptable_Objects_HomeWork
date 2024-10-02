using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "NewMapPreset", menuName = "Map/Presets")]
public class MapPresets : ScriptableObject
{
    public int _trees;
    public int _rocks;
    public int _grass;

    public int _speedBuffs;
    public int _healthBufs;


}
