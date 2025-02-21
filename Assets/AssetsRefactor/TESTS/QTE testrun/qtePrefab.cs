using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class qtePrefab : MonoBehaviour
{
    float _activeDuration;
    KeyCode triggerCode;
    qteSO reference;
    private void Awake() {
        ManagerMiddleman._onKeyPressAction += trigger;
    }

    void trigger(KeyCode _code){
        if(_code == triggerCode){
            reference.triggerInteraction();
        }
    }

    IEnumerator countdown(){
        yield return new WaitForSeconds(_activeDuration);
        Destroy(gameObject);
    }
}
