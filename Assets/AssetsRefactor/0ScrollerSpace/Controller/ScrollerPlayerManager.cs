using UnityEngine;

public class ScrollerPlayerManager : MonoBehaviour {
    [SerializeField]int durability = 6;

    private void OnEnable() {
        ScrollerMiddlemanSO.damageObject += damage;
    }

    private void OnDisable() {
        ScrollerMiddlemanSO.damageObject -= damage;
    }

    void damage(GameObject signaled){
        if(signaled != this.gameObject){
            return;
        }
        durability--;
        ScrollerMiddlemanSO.displayHealth?.Invoke(durability);
        if(durability <= 0){
            ScrollerMiddlemanSO.playerGameOver?.Invoke();
        }
    }
}