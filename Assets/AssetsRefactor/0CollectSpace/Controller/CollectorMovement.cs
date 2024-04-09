using UnityEngine;
public class CollectorMovement : PlayerOperatorBase {
    Vector2 movement;
    [SerializeField] float _speed;
    GameObject player;
    Rigidbody2D playerRb;
    CollectorInteraction _interact;
    bool dialogueActive = false;

    public override void onDialoguePrompted()
    {
        dialogueActive = !dialogueActive;
    }

    public override void computeInput(KeyCode _keyCode){}

    public override void OnEnterState(PlayerStateMachine playerStateMachine){
        ManagerMiddleman.AxisRawHorizontalVertical += computeInput;
        ManagerMiddleman.setPlayerForOperator += getPlayer;
        _interact = GetComponent<CollectorInteraction>();
    }
    public override void UpdateState(PlayerStateMachine stateMachine){}
    public override void computeInput(float _horizontal, float _vertical){
        movement = new Vector2(_horizontal, _vertical);
    }
    
    public override void OnExitState(){
        ManagerMiddleman.AxisRawHorizontalVertical -= computeInput;
        ManagerMiddleman.setPlayerForOperator -= getPlayer;
        _interact = null;
    }

    private void Update() {
        if(dialogueActive){return;}
        if(movement.magnitude >= .5f){
            playerRb.MovePosition(playerRb.position + movement * _speed * Time.fixedDeltaTime);
            _interact.setFaceDirection(movement.normalized);
        }
    }

    public void getPlayer(GameObject playerOnScene) {
        player = playerOnScene;
        playerRb = player.GetComponent<Rigidbody2D>();
    }
}