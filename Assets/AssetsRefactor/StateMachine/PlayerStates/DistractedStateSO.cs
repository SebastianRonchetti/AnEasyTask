using UnityEngine;

public abstract class DistractedStateSO : PlayerStateSO {
    public override void onEnterState(StateMachine stateMachine){}
    public override void UpdateState(StateMachine stateMachine){}
    public override void onExitState(StateMachine stateMachine){}
    public override void inputReader(InputManager.onKeyPressOrHold_eventArgs e, object sender){

    }
}