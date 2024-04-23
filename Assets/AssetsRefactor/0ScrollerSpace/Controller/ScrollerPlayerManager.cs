using UnityEngine;

public class ScrollerPlayerManager : MonoBehaviour {
    int durability;

    private void Awake() {
        ScrollerMiddlemanSO.damageObject += damage;
    }

    void damage(GameObject signaled){
        if(signaled != this.gameObject){
            return;
        }
        durability--;
        ScrollerMiddlemanSO.displayHealth?.Invoke(durability);
    }
}