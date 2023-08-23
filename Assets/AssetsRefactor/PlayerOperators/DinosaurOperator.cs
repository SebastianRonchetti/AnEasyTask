using UnityEngine;

public class DinosaurOperator : PlayerOperatorBase {
    public override void OnEnterState(PlayerStateMachine playerStateMachine) {
        ManagerMiddleman._onKeyPressOrHoldAction += computeInput;
    }

    public override void UpdateState() {

    }

    public override void computeInput(KeyCode _keyCode, float intensity) {
        if(_keyCode == KeyCode.W) {
            //jump
        }

        if(_keyCode == KeyCode.S) {
            //crouch
        }
    }

    public override void OnExitState() {

    }
}