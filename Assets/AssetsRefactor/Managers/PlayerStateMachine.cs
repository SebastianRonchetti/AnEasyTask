using UnityEngine;
using System.Collections.Generic;
using System;

public class PlayerStateMachine : StateMachine {
    List<PlayerOperatorBase> PlayerOperators;
    PlayerOperatorBase activeOperator;
    GameObject _player;

    private void Awake() {
        ManagerMiddleman._onKeyPressOrHoldAction += receiveInput;
    }

    void receiveInput(KeyCode _input, float _axisRaw) {
        //activeOperator.computeInput(_input, _axisRaw);
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
        currentState.UpdateState(this);
    }
}