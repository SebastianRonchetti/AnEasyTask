using UnityEngine;

public class CollectorInteraction : MonoBehaviour {
    GameObject player; 
    [SerializeField] GameObject _heldObject;
    [SerializeField] float pickupRadius;
    Vector3 playerFaceDirection = new Vector2(0, -1);
    [SerializeField] Transform grabPoint;
    [SerializeField] LayerMask objectsToPickUp;

    private void Start() {
        ManagerMiddleman._onKeyPressAction += computeInput;
        player = this.gameObject;
    }

    public void computeInput(KeyCode _keyCode)
    {
        Collider2D _item;
        if(_keyCode == KeyCode.Space){
            if(_heldObject != null){
                _heldObject.transform.position = player.transform.position + playerFaceDirection;
                _heldObject.transform.parent = null;
                _heldObject.GetComponent<PickableItem>().onDrop();
                _heldObject = null;
            } else if (Physics2D.OverlapCircle(player.transform.position + playerFaceDirection, 
                        pickupRadius, objectsToPickUp).TryGetComponent(out _item)){
                //pickup
                PickableItem usage;
                if(_item.TryGetComponent(out usage)){
                    usage.onPick();
                    _heldObject = _item.gameObject;
                    _heldObject.transform.position = grabPoint.position;
                    _heldObject.transform.parent = player.transform;
                }
            } else {
                Debug.Log("Aca no hay na, pa");
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