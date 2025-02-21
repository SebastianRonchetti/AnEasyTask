using UnityEngine;

public class WorkingStateSO : PlayerStateSO {
    public override void onEnterState(StateMachine machine)
    {
        base.onEnterState(machine);
    }

    public override void onExitState(StateMachine machine)
    {
        base.onExitState(machine);
    }

    public override void UpdateState(StateMachine machine)
    {
        base.UpdateState(machine);
    }

    public override void inputReader(InputManager.onKeyPressOrHold_eventArgs e, object sender)
    {
        if(isActive){
            if(e.code == KeyCode.Space){
                
            }
        }
    }
}