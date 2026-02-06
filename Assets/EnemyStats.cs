using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyStats
{
    public float health;
    public int shield;
    public float speed;

    public EnemyStats(float health, int shield, float speed)
    {
        this.health = health;
        this.shield = shield;
        this.speed = speed;
    }

    public EnemyStats(EnemyStats other)
    {
        health = other.health;
        shield = other.shield;
        speed = other.speed;
    }
}