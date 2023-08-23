using UnityEngine;

public abstract class PlayerState : MonoBehaviour {
    protected StateActionSO[] listOfActions;
    public StateMachine stateMachineReference;
    protected bool isActive = false;
    public abstract void inputReader(InputManager.onKeyPressOrHold_eventArgs e, object sender);
    public abstract void onEnterState(StateMachine machine);
    public abstract void onExitState(StateMachine machine);
    public abstract void UpdateState(StateMachine machine);
}