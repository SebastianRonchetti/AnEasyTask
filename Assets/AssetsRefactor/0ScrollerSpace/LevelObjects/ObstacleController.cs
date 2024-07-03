using UnityEngine;

public class ObstacleController : MonoBehaviour {
    /// <summary>
    /// Moves the obstacle and checks for collisions, destroying the obstacle if its integrity reaches 0 or less
    /// </summary>
    [SerializeField] int integrity, type;
    [SerializeField] float lowestSpeed, highestSpeed;
    Transform pos;

    private void OnEnable() {
        ScrollerMiddlemanSO.damageObject += damage;
        ScrollerMiddlemanSO.passCurrentTimer += Move;
        pos = this.gameObject.transform;
    }

    private void OnDisable() {
        ScrollerMiddlemanSO.damageObject -= damage;
        ScrollerMiddlemanSO.passCurrentTimer -= Move;
    }

    void obstacleDestroy(){
        ScrollerMiddlemanSO.damageObject -= damage;
        ScrollerMiddlemanSO.passCurrentTimer -= Move;
        OnDisable();
        Destroy(this.gameObject);
    }

    public void damage(GameObject signaled){
        if(signaled != this.gameObject){return;}
        integrity --;
        if(integrity <= 0){
            ScrollerMiddlemanSO.IncreaseScore?.Invoke(type);
            obstacleDestroy();
        }
    }

    void reachedEndOfScreen(){
        Destroy(this.gameObject);
    }

    void Move(float _activeTimer){
        float movement = pos.position.y - transform.forward.z * Time.fixedDeltaTime * _activeTimer;
        gameObject.transform.position = new Vector3(transform.position.x, movement,0);
    }

    void OnCollisionEnter2D(Collision2D other) {
        Physics2D.IgnoreCollision(
            this.gameObject.GetComponent<Collider2D>(), 
            other.gameObject.GetComponent<Collider2D>(), 
            true);
        switch(other.gameObject.tag){
            case "Bullet":
                Destroy(other.gameObject);
                damage(this.gameObject);
            break;
            case "Player":
                ScrollerMiddlemanSO.damageObject?.Invoke(other.gameObject);
                damage(this.gameObject);
            break;
            case "Wall":
                obstacleDestroy();
            break;
        }
    }
}