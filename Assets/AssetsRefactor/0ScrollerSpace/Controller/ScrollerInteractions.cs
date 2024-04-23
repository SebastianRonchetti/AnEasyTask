using UnityEngine;

public class ScrollerInteraction : MonoBehaviour
{
    [SerializeField] Transform shootPosition;
    [SerializeField] GameObject projectile;

    private void Awake() {
        ManagerMiddleman._onKeyPressOrHoldAction += shoot;
    }

    void shoot(KeyCode keyCode){
        //shoot 
        if(keyCode == KeyCode.Space){
            Instantiate(projectile, shootPosition);
        }
    }
}
