using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class ScrollerObstacleSpawnManager : MonoBehaviour {
    [SerializeField] GameObject[] spawners;
    [SerializeField] SpawnObjectRandomizer _randomizer;
    [Range(1.5f, 5f)]
    [SerializeField] float activeCooldownVal;
    bool cooldownRunning = false;

    private void Awake() {
        ScrollerMiddlemanSO.setObstacleSpawnCooldown += getCooldown;
    }

    void OnDisable(){
        ScrollerMiddlemanSO.setObstacleSpawnCooldown -= getCooldown;
    }

    private void Update() {
        if(!cooldownRunning){
            spawnObstacles(selectSpawners());
            StartCoroutine(ActiveCooldown());
        }
    }

    List<GameObject> selectSpawners(){
        //UnityEngine.Random.InitState(Convert.ToInt32(Time.deltaTime));
        List<GameObject> _selectedSpawners = new List<GameObject>();
        List<GameObject> _spawnPointPool = spawners.ToList();
        int _amountToSpawn = UnityEngine.Random.Range(1, 7);
        for(int i = 0; i < _amountToSpawn; i++){
            //select one spawn position, build up the list.
            GameObject _selectedSpawner = _spawnPointPool[UnityEngine.Random.Range(0, _spawnPointPool.Count())];
            _selectedSpawners.Add(_selectedSpawner);
            _spawnPointPool.Remove(_selectedSpawner);
        }
        return _selectedSpawners;
    }

    void spawnObstacles(List<GameObject> _selectedSpawners){
        foreach(GameObject _spawnPoint in _selectedSpawners){
            float spawnChance = UnityEngine.Random.Range(0, 100);
            Instantiate(_randomizer.ObjectRolled(spawnChance), _spawnPoint.transform);
        }
    }

    void getCooldown(float _cooldown){
        activeCooldownVal = _cooldown;
        StopCoroutine(ActiveCooldown());
    }

    private IEnumerator ActiveCooldown(){
        cooldownRunning = true;
        yield return new WaitForSeconds(activeCooldownVal);
        cooldownRunning = false;
    }
}