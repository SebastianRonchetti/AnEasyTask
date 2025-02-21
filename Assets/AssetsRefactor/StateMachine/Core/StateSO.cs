using UnityEngine;

[CreateAssetMenu(fileName = "StateSO", menuName = "AnEasyTaskv0.1/StateSO", order = 0)]
public abstract class StateSO : ScriptableObject {
    //StateMachine stateMachine;
    protected StateActionSO[] listOfActions;
    public StateMachine stateMachineReference;
    protected bool isActive = false;

    void Awake() {
        stateMachineReference.AddState(this);
    }

    public abstract void onEnterState(StateMachine stateMachine);

    public abstract void UpdateState(StateMachine stateMachine);

    public abstract void onExitState(StateMachine stateMachine);
}