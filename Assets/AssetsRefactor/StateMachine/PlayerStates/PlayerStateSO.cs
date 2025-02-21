using UnityEngine;

public abstract class PlayerStateSO : StateSO {

    public abstract void inputReader(InputManager.onKeyPressOrHold_eventArgs e, object sender);
    public override void onEnterState(StateMachine machine){isActive = true;}
    public override void onExitState(StateMachine machine){isActive = false;}
    public override void UpdateState(StateMachine machine){}
}