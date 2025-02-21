using UnityEngine;

public class LocalPlayerManager : MonoBehaviour {
    private void OnEnable() {
        ManagerToOutMiddle.setPlayerOnScene(this.gameObject);
    }
    private void OnDisable(){
        ManagerToOutMiddle.setPlayerOnScene(null);
    }
}