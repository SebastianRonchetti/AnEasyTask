using System;
using UnityEngine;

public class GameManager : SingletonClass<GameManager> {
    InputManager _inputManager;
    PlayerManager _playerManager;
    GameSceneManager _gameSceneManager;
    float storedWork;

    private void Awake() {
        ManagerMiddleman._loadWorkSceneAction += onWorkSceneLoadedTrigger;
    }

    void onWorkSceneLoadedTrigger(){
    }

    void onWorkSceneUnload(float _progressValue){
        storedWork = _progressValue;
    }

    private void onDisable() {
        ManagerMiddleman._loadWorkSceneAction -= onWorkSceneLoadedTrigger;
    }
}