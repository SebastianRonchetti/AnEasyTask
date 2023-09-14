using UnityEngine;

public class CollectorOperator : PlayerOperatorBase {
    PlayerManager playerManager;
    public override void OnEnterState(PlayerStateMachine playerStateMachine){
        ManagerMiddleman.AxisRaw += computeInput;
        getPlayer();
    }
    public override void UpdateState(){}
    public override void computeInput(float _horizontal, float _vertical){
        
        Vector2 movement = new Vector2(_horizontal, _vertical);
    }
    public override void OnExitState(){
        ManagerMiddleman.AxisRaw -= computeInput;
    }

    private void FixedUpdate() {
        float _vertical = Input.GetAxisRaw("Vertical");
        float _horizontal = Input.GetAxisRaw("Horizontal");
    }

    public override void getPlayer()
    {
        
    }
}