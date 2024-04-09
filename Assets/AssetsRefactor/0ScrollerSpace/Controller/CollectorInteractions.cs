using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CollectorInteractions : MonoBehaviour
{
    [SerializeField] Transform shootPosition;
    [SerializeField] GameObject projectile;

    private void Awake() {
        ManagerMiddleman._onKeyPressOrHoldAction += shoot;
    }

    void shoot(KeyCode keyCode){
        //shoot 
        GameObject activeProjectile = Instantiate(projectile, shootPosition);
    }
}
