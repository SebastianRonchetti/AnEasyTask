using UnityEngine;

public class ObstacleController : MonoBehaviour {
    /// <summary>
    /// Moves the obstacle and checks for collisions, destroying the obstacle if its integrity reaches 0 or less
    /// </summary>
    [SerializeField] int integrity, type;
    [SerializeField] float speed;
    Transform pos;

    private void OnEnable() {
        ScrollerMiddlemanSO.damageObject += damage;
    }

    public void damage(GameObject signaled){
        if(signaled != this.gameObject){
            return;
        }
        integrity --;
        if(integrity <= 0){
            Destroy(this.gameObject);
            ScrollerMiddlemanSO.IncreaseScore?.Invoke(type);
        }
    }

    void reachedEndOfScreen(){
        Destroy(this.gameObject);
    }

    private void Update() {
        Move();
    }

    void Move(){
        Vector3 back = transform.forward * -1;
        pos.position = back * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Wall")){
            reachedEndOfScreen();
        }
        ScrollerMiddlemanSO.damageObject?.Invoke(other.gameObject);
        ScrollerMiddlemanSO.damageObject?.Invoke(this.gameObject);
    }
}