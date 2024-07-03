using UnityEngine;
public class WorkingOperator : PlayerOperatorBase {
    public override void onDialoguePrompted()
    {
        throw new System.NotImplementedException();
    }
    public override void OnEnterState(PlayerStateMachine playerStateMachine){
        ManagerMiddleman._onKeyHoldAction += computeInput;
    }
    public override void UpdateState(PlayerStateMachine stateMachine){}
    public override void computeInput(KeyCode _keyCode){
        if(_keyCode == KeyCode.Space){
            ManagerMiddleman.workStationConcentrating?.Invoke();
        }
    }
    public override void computeInput(float _horizontal, float _vertical){}
    public override void OnExitState(){
        ManagerMiddleman._onKeyHoldAction -= computeInput;
    }
}