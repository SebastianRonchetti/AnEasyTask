using UnityEngine;
using System.Collections.Generic;
using System;

class PlayerManager : MonoBehaviour {
    StateMachine PlayerStateMachine;
    List<PlayerOperatorBase> PlayerOperators;
    PlayerOperatorBase activeOperator;
    GameObject _player;

    private void Awake() {
        PlayerStateMachine = new StateMachine();
        //PlayerStateMachine.AddState();
    }

    private void Start() {
    }

    void receiveInput(object sender, InputManager.onKeyPressOrHold_eventArgs e) {
        
    }

    void changeActiveMode(object sender, EventArgs e) {
        //Listens to a gameManager event which specifies the active operator to be loaded
        foreach(PlayerOperatorBase op in PlayerOperators) {
            /* if(e.sceneIdentity == op._operativeScene) {
                activeOperator.OnExitState();
                activeOperator = op;
                activeOperator.OnEnterState();
                break;
            } */
        }
    }

    void movePlayer() {

    }

    private void Update() {
        PlayerStateMachine.currentState.UpdateState(PlayerStateMachine);
    }
}