using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManagerPoV : SingletonClass<PlayerManagerPoV>
{
    public static event EventHandler<EventArgs> onFocus;
    [SerializeField]bool focusing = false, awaitingInput = true;

    private void Awake() {
        this._instantiate();
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManagerPoV.awaitInput += onWaitForInput;
    }
    private void OnDestroy() {
        GameManagerPoV.awaitInput -= onWaitForInput;
    }
    void onWaitForInput(object sender, EventArgs e){
        awaitingInput = true;
    }

    // Update is called once per frame
    private void Update() {
        if(awaitingInput){
            if(Input.anyKey) {
                awaitingInput = false;
                if(Input.GetKeyDown(KeyCode.Space)){
                    focusing = true;
                }
            }
        }else{
            if(focusing){
                if(Input.GetKey(KeyCode.Space)) {
                    onFocus?.Invoke(this, new EventArgs());
                    focusing = true;
                } else if (Input.GetKeyUp(KeyCode.Space) || (Input.GetKey(KeyCode.W)
                    || Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)
                    || Input.GetKey(KeyCode.D))) 
                {
                    focusing = false;
                }
            } else {
                /*
                float _horizontalInput = Input.GetAxisRaw("Horizontal");
                float _verticalInput = Input.GetAxisRaw("Vertical");
                movement = new Vector2(_horizontalInput, _verticalInput);

                 if(Input.GetKeyDown(KeyCode.Space)) {
                    //pick up or drop object
                    if(heldObject){
                        //drop
                        Collider2D receptorCol = Physics2D.OverlapCircle(transform.position + _faceDirection, pickupRadius, objectReceptors);
                        if(receptorCol != null) {
                            Receptor receptor = receptorCol.GetComponent<Receptor>();
                            receptor.guardarObjeto(heldObject);
                        }
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
                } */
            }
        }
    }
}
