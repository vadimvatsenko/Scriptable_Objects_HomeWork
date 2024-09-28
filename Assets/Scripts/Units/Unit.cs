using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private CharacterStats _baseCharacterStats;
    private CharacterStats _currentCharacterStats;
    private CharacterStatsEvent _characterStatsEvent;
    public Character _character { get; private set; }
    private void Start()
    {
        _baseCharacterStats = Resources.Load<CharacterStats>("ScriptableObjects/BaseCharacterStats");
        _currentCharacterStats = Resources.Load<CharacterStats>("ScriptableObjects/NewCharacterStats");
        _characterStatsEvent = Resources.Load<CharacterStatsEvent>("ScriptableObjects/NewStatsEvent");
        _character = new Character(_baseCharacterStats, _currentCharacterStats);
        Debug.Log(_character.CurrentStats.health);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.name)
        {
            case "Heal_Up(Clone)":
                _character.AddBuff(new HealthBuff(5));

                Destroy(other.gameObject);

                _characterStatsEvent.CharacterEvent(_character.CurrentStats.health);
                break;
            case "Power_Up(Clone)":

                _character.AddBuff(new TemporaryBuff(_character, new SpeedBuff(2), 4000));
                Destroy(other.gameObject);
                break;

        }
    }

}
