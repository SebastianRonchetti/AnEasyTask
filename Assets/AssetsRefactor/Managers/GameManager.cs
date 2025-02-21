using System;
using UnityEngine;

public class GameManager : SingletonClass<GameManager> {
    DialogueUI _dialogueUI;

    private void Awake() {
        ManagerMiddleman._loadWorkSceneAction += onWorkSceneLoadedTrigger;
        //ManagerMiddleman._setManagerReference += setManagerReference;
    }

    void onWorkSceneLoadedTrigger(){
    }

    private void onDisable() {
        ManagerMiddleman._loadWorkSceneAction -= onWorkSceneLoadedTrigger;
    }

    private void setManagerReference(DialogueUI UI){
        _dialogueUI = UI;
        _dialogueUI.CloseDialogueBox();
    }
}