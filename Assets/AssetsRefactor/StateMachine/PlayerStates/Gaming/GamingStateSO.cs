using UnityEngine;
using System;

public class GamingStateSO : DistractedStateSO {
    public event EventHandler<onPlayerMove_eventArgs> onPlayerMove;
    public class onPlayerMove_eventArgs : EventArgs {
        //public ;
    }
    public override void onEnterState(StateMachine stateMachine){
        isActive = true;
    }

    public override void UpdateState(StateMachine stateMachine){

    }

    public override void onExitState(StateMachine stateMachine){
        isActive = false;
    }

    public override void inputReader(InputManager.onKeyPressOrHold_eventArgs e, object sender)
    {
        if(isActive){
            if(e.code == KeyCode.W) {
                
            }
            if(e.code == KeyCode.A) {

            }
            if(e.code == KeyCode.S) {
                
            }
            if(e.code == KeyCode.D) {
                
            }
            if(e.code == KeyCode.Space) {

            }
        }
        /* 
        
        */
    }
}