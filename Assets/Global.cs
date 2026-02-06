using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Global : ScriptableObject
{
    public static bool isDataLoaded = false;

    public static Dictionary<EnemyType, EnemyStats> enemyValues = new();

    public enum EnemyType
    {
        Basic,
        Shielded
    }

    private void Awake()
    {
        //noop
    }
}
