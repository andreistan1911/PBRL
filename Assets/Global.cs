using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public static class Global
{
    public static bool isDataLoaded = false;

    public static Dictionary<EnemyType, EnemyStats> enemyValues = new();

    public enum EnemyType
    {
        Basic,
        Shielded
    }
}
