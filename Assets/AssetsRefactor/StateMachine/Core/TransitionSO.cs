using UnityEngine;

public abstract class StateTransitionSO : ScriptableObject {
    StateMachine stateMachineReference;
    StateSO currentState;
    StateSO[] possibleStates;

    public virtual void performTransition(StateMachine stateMachine, StateSO nextState) {
        stateMachine.currentState.onExitState(stateMachine);
        
    }    
}