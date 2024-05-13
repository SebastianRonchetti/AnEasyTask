using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ObstacleSpawnTemplateSO", menuName = "Scroller/Obstacle Spawn TemplateSO", order = 0)]
public class ObstacleSpawnTemplateSO : ScriptableObject {
    /// <summary>
    /// checks if the broadcasted spawn chance is within the boundaries of its own spawn chance and in case it is
    /// the script triggers each command in a list.
    /// </summary>
    public List<ObstacleSpawnCommandSO> commands;
    float spawnChanceLow, spawnChanceHigh;
    
    public void suscribeToEvents(){
        ScrollerMiddlemanSO.spawnObstaclesBasedOnChance += activate;
        ScrollerMiddlemanSO.UnloadSubscriptions += unsuscribeFromEvents;
    }

    public void unsuscribeFromEvents(){
        ScrollerMiddlemanSO.spawnObstaclesBasedOnChance -= activate;
        ScrollerMiddlemanSO.UnloadSubscriptions -= unsuscribeFromEvents;
    }
    
    void activate(float roll, GameObject[] _spawners){
        if(spawnChanceLow < roll && roll < spawnChanceHigh){
            foreach(ObstacleSpawnCommandSO _command in commands){
                _command.activate(_spawners[_command.Spawner - 1]);
            }
        }
    }

    public float retSpawnChanceLow(){
        return spawnChanceLow;
    }
    
    public float retSpawnChanceHigh(){
        return spawnChanceHigh;
    }
}