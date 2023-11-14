using UnityEngine;
using System;
using UnityEngine.UIElements;

public class InputManager : SingletonClass<InputManager> {
    private void Awake() {
        this._instantiate();
    }
    public static event EventHandler<onKeyPressOrHold_eventArgs> onKeyPressOrHold;
    public class onKeyPressOrHold_eventArgs : EventArgs {
        public KeyCode code;
        public float axisRaw;
    }
    void Update() {
/* 
        if(Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space)){
            ManagerMiddleman._onKeyPressOrHoldAction?.Invoke(KeyCode.Space, 0);
        }

        if(Input.GetKeyDown(KeyCode.A)) {
            float _temp = Input.GetAxisRaw("Horizontal");
            ManagerMiddleman._onKeyPressOrHoldAction?.Invoke(KeyCode.A, _temp);
        }
        
        if(Input.GetKeyDown(KeyCode.S)) {
            float _temp = Input.GetAxisRaw("Vertical");
            ManagerMiddleman._onKeyPressOrHoldAction?.Invoke(KeyCode.S, _temp);
        }
        
        if(Input.GetKeyDown(KeyCode.D)) {
            float _temp = Input.GetAxisRaw("Horizontal");
            ManagerMiddleman._onKeyPressOrHoldAction?.Invoke(KeyCode.D, _temp);
        }
        
        if(Input.GetKeyDown(KeyCode.W)) {
            float _temp = Input.GetAxisRaw("Vertical");
            ManagerMiddleman._onKeyPressOrHoldAction?.Invoke(KeyCode.W, _temp);
        }
 */
    }
    
    private void FixedUpdate() {
        float _vertical = Input.GetAxisRaw("Vertical");
        float _horizontal = Input.GetAxisRaw("Horizontal");

        ManagerMiddleman.AxisRawHorizontalVertical?.Invoke(_horizontal, _vertical);

        if(Input.GetKeyDown(KeyCode.E) || Input.GetKey(KeyCode.E)) {
            ManagerMiddleman._onKeyPressOrHoldAction(KeyCode.E);
        }

        if(Input.GetKeyDown(KeyCode.Q) || Input.GetKey(KeyCode.Q)){
            ManagerMiddleman._onKeyPressOrHoldAction(KeyCode.Q);
        }

        if(Input.GetKeyDown(KeyCode.X) || Input.GetKey(KeyCode.X)){
            ManagerMiddleman._onKeyPressOrHoldAction(KeyCode.X);
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space)){
            ManagerMiddleman._onKeyPressOrHoldAction(KeyCode.Space);
        }

        if(Input.GetKeyUp(KeyCode.Space)){
            ManagerMiddleman.concentrationStopped?.Invoke(KeyCode.Space);
        }
    }
}