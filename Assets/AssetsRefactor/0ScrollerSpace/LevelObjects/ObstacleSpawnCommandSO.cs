using UnityEngine;
using System;

public class ObstacleSpawnCommandSO : ScriptableObject {
    /// <summary>
    /// Spawns an obstacle from the designated spawn-point
    /// </summary>
    GameObject spawner;
    GameObject spawnee;

    public void activate(){
        Instantiate(spawnee, spawner.transform);
    }
}