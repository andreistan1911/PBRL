using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    // TODO

    private TextAsset enemyJSON;

    [System.Serializable]
    public class EnemyParsed
    {
        public string type;
        public float health;
        public int shield;
        public float speed;

        public override string ToString()
        {
            return $"type: {type}, health: {health}, shield: {shield}, speed: {speed}";
        }
    }

    [System.Serializable]
    public class EnemyParsedList
    {
        public EnemyParsed[] enemy;
    }

    [HideInInspector]
    public EnemyParsedList enemyParsedList = new();

    private void Awake()
    {
        if (Global.isDataLoaded)
            return;

        enemyJSON = Resources.Load<TextAsset>("JSON/Enemies");

        ReadEnemies();

        Global.isDataLoaded = true;
    }
    private void ReadEnemies()
    {
        enemyParsedList = JsonUtility.FromJson<EnemyParsedList>(enemyJSON.text);

        for (int i = 0; i < enemyParsedList.enemy.Length; ++i)
        {
            EnemyParsed currentEnemy = enemyParsedList.enemy[i];
            EnemyStats enemyStats = new(currentEnemy.health, currentEnemy.shield, currentEnemy.speed);

            Global.enemyValues.Add(ParseEnemyType(currentEnemy.type), enemyStats);

            Debug.Log(currentEnemy);
        }
    }


    private Global.EnemyType ParseEnemyType(string type)
    {
        return type switch
        {
            "Basic" => Global.EnemyType.Basic,
            "Shielded" => Global.EnemyType.Shielded,
            _ => Global.EnemyType.Basic
        };
    }
}