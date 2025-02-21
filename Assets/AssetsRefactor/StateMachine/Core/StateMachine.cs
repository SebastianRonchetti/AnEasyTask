using UnityEngine;
using System.Collections.Generic;

public class StateMachine : MonoBehaviour {
    private StateTransitionSO[] listOfTransitions;
    private StateActionSO[] stateActions;
    public StateSO currentState;
    private List<StateSO> stateTypeList;
    //private Dictionary<> a;

    private void Awake() {
        stateTypeList = new List<StateSO>();
    }

    public void AddState(StateSO state)
    {
        foreach(StateSO savedState in stateTypeList){
            if(savedState.GetType() == state.GetType()){
                break;
            }
            stateTypeList.Add(state);
        }
    }

    private void Start() {
        currentState = stateTypeList[0];
    }

    private void changeState(StateSO futureState){
        currentState.onExitState(this);
        currentState = futureState;
        currentState.onEnterState(this);
    }
}