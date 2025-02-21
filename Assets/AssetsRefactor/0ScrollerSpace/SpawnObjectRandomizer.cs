using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnObjectRandomizer", menuName = "Global/SpawnObjectRandomizer", order = 0)]
public class SpawnObjectRandomizer : ScriptableObject{
    [SerializeField] private List<SpawnObject> _randomObjectTable;
    public List<SpawnObject> RandomObjectTable => _randomObjectTable;
    public GameObject ObjectRolled (float roll){
        foreach(SpawnObject Object in _randomObjectTable){
            if(Object.LowSpawnChance <= roll && roll <= Object.HighSpawnChance){
                return Object.Object;
            }
        }
        return null;
    }
}