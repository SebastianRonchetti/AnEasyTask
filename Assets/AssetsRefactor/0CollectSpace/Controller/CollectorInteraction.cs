using UnityEngine;

public class CollectorInteraction : MonoBehaviour {
    GameObject player;
    GameObject _heldObject;
    [SerializeField] float pickupRadius;
    Vector3 playerFaceDirection = new Vector2(0, -1);
    [SerializeField] Transform grabPoint;
    [SerializeField] LayerMask objectsToPickUp;

    private void Start() {
        ManagerMiddleman._onKeyPressOrHoldAction += computeInput;
    }

    public void computeInput(KeyCode _keyCode)
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
                    _heldObject.transform.position = grabPoint.position;
                    _heldObject.transform.parent = player.transform;
                }
            }
        }
    }

    public void setFaceDirection(Vector2 face){
        playerFaceDirection = face;
    }

    public void getPlayer(GameObject playerOnScene) {
        player = playerOnScene;
    }
}