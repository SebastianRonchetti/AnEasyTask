using UnityEngine;
using System.Collections;

public class ScrollerInteraction : MonoBehaviour
{
    [SerializeField] Transform shootPosition;
    [SerializeField] GameObject projectile;
    [SerializeField] float shootCooldown = 0.3f;
    [SerializeField]bool activeCooldown;

    private void Awake() {
        ManagerMiddleman._onKeyPressOrHoldAction += shootCommand;
        ManagerMiddleman._onKeyPressOrHoldAction += pauseUnpause;
    }

    void OnDisable(){
        ManagerMiddleman._onKeyPressOrHoldAction -= shootCommand;
        ManagerMiddleman._onKeyPressOrHoldAction -= pauseUnpause;
    }

    void shootCommand(KeyCode keyCode){
        //shoot 
        if(keyCode == KeyCode.Space && !activeCooldown){
            shoot();
            StartCoroutine(cooldown());
        }
    }

    void shoot(){
        GameObject _projectileInstance = Instantiate(projectile, this.transform.parent);
        _projectileInstance.transform.position = shootPosition.position;
    }

    IEnumerator cooldown(){
        activeCooldown = true;
        yield return new WaitForSeconds(shootCooldown);
        activeCooldown = false;
    }

    void pauseUnpause(KeyCode _pauseCommand){
        if(_pauseCommand == KeyCode.M){
            TempMiddleman.pauseGame?.Invoke();
        }
    }
}
