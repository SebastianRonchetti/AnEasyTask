using UnityEngine;
using System;
[CreateAssetMenu(fileName = "ObstacleSpawnCommandSO", menuName = "Scroller/Obstacle Spawn CommandSO", order = 0)]
public class ObstacleSpawnCommandSO : ScriptableObject {
    /// <summary>
    /// Spawns an obstacle from the designated spawn-point
    /// </summary>
    [SerializeField]int _spawner;
    [SerializeField]GameObject _spawnee;
    public int Spawner => _spawner;
    public GameObject Spawnee => _spawnee;

    public void activate(GameObject _spawnerObject){
        Instantiate(Spawnee, _spawnerObject.transform);
    }
}