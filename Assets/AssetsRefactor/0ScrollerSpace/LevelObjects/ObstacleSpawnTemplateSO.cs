using UnityEngine;
using System;
using System.Collections.Generic;

public class ObstacleSpawnTemplateSO : ScriptableObject {
    /// <summary>
    /// checks if the broadcasted spawn chance is within the boundaries of its own spawn chance and in case it is
    /// the script triggers each command in a list.
    /// </summary>
    public List<ObstacleSpawnCommandSO> commands;
    public float spawnChance;
    public void activate(){
        foreach(ObstacleSpawnCommandSO _command in commands){
            _command.activate();
        }
    }
}