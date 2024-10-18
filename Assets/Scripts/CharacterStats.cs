using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterStats", menuName = "Character/Stats")]
public class CharacterStats : ScriptableObject
{
    public int health;
    public int speed;
    public int attackDamage;
    public int coins;

    public void CopyStats(CharacterStats newStats) // перезапись баффов
    {
        health = newStats.health;
        speed = newStats.speed;
        attackDamage = newStats.attackDamage;
        coins = newStats.coins;
    }
}
