using UnityEngine;
[System.Serializable]
public class SpawnObject {
    [SerializeField] private GameObject _object;
    [SerializeField] private float _lowSpawnChance, _highSpawnChance;
    public GameObject Object => _object;
    public float LowSpawnChance => _lowSpawnChance;
    public float HighSpawnChance => _highSpawnChance;
}