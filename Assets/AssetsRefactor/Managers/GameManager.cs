using System;
using UnityEngine;

public class GameManager : SingletonClass<GameManager> {
    InputManager _inputManager;
    PlayerManager _playerManager;
    GameSceneManager _gameSceneManager;
    DialogueUI _dialogueUI;
    float storedWork;

    private void Awake() {
        ManagerMiddleman._loadWorkSceneAction += onWorkSceneLoadedTrigger;
        ManagerMiddleman._setManagerReference += setManagerReference;
    }

    void onWorkSceneLoadedTrigger(){
    }

    void onWorkSceneUnload(float _progressValue){
        storedWork = _progressValue;
    }

    private void onDisable() {
        ManagerMiddleman._loadWorkSceneAction -= onWorkSceneLoadedTrigger;
    }

    private void setManagerReference(DialogueUI UI){
        _dialogueUI = UI;
        _dialogueUI.CloseDialogueBox();
    }
}