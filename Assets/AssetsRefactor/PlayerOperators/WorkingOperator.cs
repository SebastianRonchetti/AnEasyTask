using UnityEngine;
[CreateAssetMenu(fileName = "WorkingOperator", menuName = "AnEasyTaskv0.1/PlayerOperators/WorkingOperator", order = 0)]
public class WorkingOperator : PlayerOperatorBase {
    public override void OnEnterState(PlayerStateMachine playerStateMachine){
        ManagerMiddleman._onKeyPressOrHoldAction += computeInput;
    }
    public override void UpdateState(PlayerStateMachine stateMachine){}
    public override void computeInput(KeyCode _keyCode){
        if(_keyCode == KeyCode.Space){
            ManagerMiddleman.workStationConcentrating?.Invoke();
        }
    }
    public override void computeInput(float _horizontal, float _vertical){}
    public override void OnExitState(){
        ManagerMiddleman._onKeyPressOrHoldAction -= computeInput;
    }
}