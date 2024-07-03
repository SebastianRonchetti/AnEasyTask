using UnityEngine;
using System;

public class ScrollerMiddlemanSO : ScriptableObject {
    public static Action playerGameOver;
    public static Action spawnObstacles;
    public static Action<GameObject> damageObject;
    public static Action<int> IncreaseScore;
    public static Action<int> displayHealth;
    public static Action<float> setObstacleSpawnCooldown;
    public static Action<float, GameObject[]> spawnObstaclesBasedOnChance;
    public static Action<float> passCurrentTimer;
}