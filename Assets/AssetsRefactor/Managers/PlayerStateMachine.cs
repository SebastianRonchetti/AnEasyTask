using UnityEngine;
using System.Collections.Generic;
using System;

public class PlayerStateMachine : MonoBehaviour {
    [SerializeField] List<PlayerOperatorBase> PlayerOperators;
    PlayerOperatorBase activeOperator;
    
    [SerializeField] bool TestMODE;
    [SerializeField] PlayerOperatorBase ACTIVEOPERATORONSCENE;
    [SerializeField] string sceneCODETEST;

    private void Awake() {
        if(TestMODE){
            activeOperator = ACTIVEOPERATORONSCENE;
            activeOperator.OnEnterState(this);
        }
        ManagerMiddleman._loadSceneAction += changeActiveMode;
        changeActiveMode("workScene");
    }

    void changeActiveMode(string _sceneID) {
        //Listens to a gameManager event which specifies the active operator to be loaded
        foreach(PlayerOperatorBase op in PlayerOperators) {
            if(_sceneID == op.SceneID) {
                if(activeOperator != null){
                    activeOperator.OnExitState();
                }
                activeOperator = op;
                activeOperator.OnEnterState(this);
                break;
            } 
        }
    }

    private void Update() {
        activeOperator.UpdateState(this);
    }
}