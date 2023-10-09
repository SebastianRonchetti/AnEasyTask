using UnityEngine;
[CreateAssetMenu(fileName = "CollectorOperator", menuName = "AnEasyTaskv0.1/PlayerOperators/CollectorOperator", order = 0)]
public class CollectorOperator : PlayerOperatorBase {
    Vector2 movement;
    [SerializeField] float _speed, pickupRadius = 2f;
    GameObject player;
    Rigidbody2D playerRb;
    GameObject _heldObject;
    Vector3 playerFaceDirection = new Vector2(0, -1), grabPoint;
    [SerializeField]LayerMask objectsToPickUp;

    public override void OnEnterState(PlayerStateMachine playerStateMachine){
        ManagerMiddleman.AxisRawHorizontalVertical += computeInput;
        ManagerMiddleman.setPlayerForOperator += getPlayer;
    }
    public override void UpdateState(PlayerStateMachine stateMachine){}
    public override void computeInput(float _horizontal, float _vertical){
        movement = new Vector2(_horizontal, _vertical);
    }
    public override void computeInput(KeyCode _keyCode)
    {
        if(_keyCode == KeyCode.Space){
            if(_heldObject != null){
                _heldObject.transform.position = player.transform.position + playerFaceDirection;
                _heldObject.transform.parent = null;
                _heldObject = null;
            } else {
                //pickup
                Collider2D _item = Physics2D.OverlapCircle(player.transform.position + playerFaceDirection, pickupRadius, objectsToPickUp);
                if(_item != null) {
                    _heldObject = _item.gameObject;
                    _heldObject.transform.position = grabPoint;
                    _heldObject.transform.parent = player.transform;
                }
            }
        }
    }
    public override void OnExitState(){
        ManagerMiddleman.AxisRawHorizontalVertical -= computeInput;
        ManagerMiddleman.setPlayerForOperator -= getPlayer;
    }

    private void Update() {
        if(movement.magnitude >= .5f){
            playerRb.MovePosition(playerRb.position + movement * _speed * Time.fixedDeltaTime);
            playerFaceDirection = movement.normalized;
        }
    }

    public void getPlayer(GameObject playerOnScene) {
        player = playerOnScene;
        playerRb = player.GetComponent<Rigidbody2D>();
        grabPoint = player.transform.position;
    }
}