using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[CreateAssetMenu(fileName = "NewStatsEvent", menuName = "Character/Event")]
public class CharacterStatsEvent : ScriptableObject
{
    public delegate void CharacterStatsDelegate(int value);
    public event CharacterStatsDelegate OnEventCharacterStatsDelegate;

    public void CharacterEvent(int value)
    {
        OnEventCharacterStatsDelegate?.Invoke(value);
    }
}
