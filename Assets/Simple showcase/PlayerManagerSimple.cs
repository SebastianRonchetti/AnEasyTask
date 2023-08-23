using UnityEngine;
using System;

public class PlayerManagerSimple : SingletonClass<PlayerManagerSimple> {
    Rigidbody2D rigidbody;
    Collider2D collider;
    [SerializeField]Transform grabPoint, dropPoint;
    [SerializeField]LayerMask objectsToPickUp, objectReceptors;
    GameObject heldObject;
    bool focusing = false, awaitingInput = true;
    public static event EventHandler<EventArgs> onFocusing;
    [SerializeField] float moveSpeed, pickupRadius = 2f;
    Vector2 movement;
    Vector3 _faceDirection {get; set;}
    GameManagerSimple gm;

    static PlayerManagerSimple instance;

    private void Start() {
        _faceDirection = new Vector2(0, -1);
        gm = GameManagerSimple.Instance;
        gm.awaitInput += onWaitForInput;
    }

    private void Awake() {
        this._instantiate();
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    void onWaitForInput(object sender, EventArgs e){
        awaitingInput = true;
    }

    private void Update() {/* 
        if(awaitingInput){
            Debug.Log("Espero");
            if(Input.anyKey) {
                awaitingInput = false;
                if(Input.GetKeyDown(KeyCode.Space)){
                    focusing = true;
                    Debug.Log("me concentro");
                }
            }
        }else{
            if(focusing){ 
                if(Input.GetKey(KeyCode.Space)) {
                    onFocusing?.Invoke(this, new EventArgs());
                    focusing = true;
                } else if (Input.GetKeyUp(KeyCode.Space) || (Input.GetKey(KeyCode.W)
                    || Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)
                    || Input.GetKey(KeyCode.D))) 
                {
                    focusing = false;
                }*/
            //} else {
                if(Input.GetKeyDown(KeyCode.E)){
                    //return to work
                }
                float _horizontalInput = Input.GetAxisRaw("Horizontal");
                float _verticalInput = Input.GetAxisRaw("Vertical");
                movement = new Vector2(_horizontalInput, _verticalInput);

                if(Input.GetKeyDown(KeyCode.Space)) {
                    //pick up or drop object
                    if(heldObject){
                        //drop
                        /*Collider2D receptorCol = Physics2D.OverlapCircle(transform.position + _faceDirection, pickupRadius, objectReceptors);
                        if(receptorCol != null) {
                            Receptor receptor = receptorCol.GetComponent<Receptor>();
                            receptor.guardarObjeto(heldObject);
                        }*/
                        heldObject.transform.position = transform.position + _faceDirection;
                        heldObject.transform.parent = null;
                        heldObject = null;
                    } else {
                        //pickup
                        Collider2D _item = Physics2D.OverlapCircle(transform.position + _faceDirection, pickupRadius, objectsToPickUp);
                        if(_item != null) {
                            heldObject = _item.gameObject;
                            heldObject.transform.position = grabPoint.position;
                            heldObject.transform.parent = transform;
                        }
                    }
                }
            //}
        //}
    }

    private void FixedUpdate() {
        if(movement.magnitude >= .5f){
            rigidbody.MovePosition(rigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);
            _faceDirection = movement.normalized;
        }
    }

    public void stopConcentrating(){
        focusing = false;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(grabPoint.position, pickupRadius);
    }
}