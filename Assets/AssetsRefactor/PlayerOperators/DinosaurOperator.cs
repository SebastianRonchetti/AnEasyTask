using UnityEngine;
public class ScrollerOperator : PlayerOperatorBase {
    float movement;
    [SerializeField] float _speed;
    GameObject player;
    Rigidbody2D playerRb;
    bool movingAlive = true;
    public override void onDialoguePrompted()
    {
        throw new System.NotImplementedException();
    }

    public override void OnEnterState(PlayerStateMachine playerStateMachine) {
        ManagerMiddleman.AxisRawHorizontalVertical += computeInput;
        ManagerMiddleman.setPlayerForOperator += getPlayer;
    }

    public override void UpdateState(PlayerStateMachine stateMachine) {

    }

    public override void computeInput(float _horizontal, float _vertical){
        movement =  _vertical;
    }

    public override void computeInput(KeyCode _keyCode)
    {
        if(_keyCode == KeyCode.Space){
            //pause
        }

        if(_keyCode == KeyCode.X){
            
        }
    }

    private void Update() {
        if(movingAlive) {
            if(movement < 0){
                //crouch
            } else if (movement > 0) {
                //jump
            } else {
                //run straight
            }
        }
    }

    public override void OnExitState() {
        player = null;
        playerRb = null;
        ManagerMiddleman.setPlayerForOperator -= getPlayer;
    }

    public void getPlayer(GameObject playerOnScene) {
        player = playerOnScene;
        playerRb = player.GetComponent<Rigidbody2D>();
    }
}