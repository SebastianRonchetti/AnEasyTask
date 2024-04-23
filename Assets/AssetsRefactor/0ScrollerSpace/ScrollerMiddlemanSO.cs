using UnityEngine;
using System;

public class ScrollerMiddlemanSO : ScriptableObject {
    public static Action playerGameOver;
    public static Action spawnObstacles;
    public static Action<GameObject> damageObject;
    public static Action<int> IncreaseScore;
    public static Action<int> displayHealth;
}