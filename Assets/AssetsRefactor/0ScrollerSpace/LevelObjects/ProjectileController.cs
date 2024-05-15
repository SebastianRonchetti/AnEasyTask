using UnityEngine;

public class ProjectileController : MonoBehaviour {
    Transform pos;
    [Range(10, 15)]
    [SerializeField] float speed = 15;
    [Range(2, 5)]
    [SerializeField] float lifeTime = 5;

    private void Awake() {
        pos = gameObject.transform;
    }

    /*private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log($"UY! choque con {other.gameObject}");
        if(other.gameObject.CompareTag("Obstacle")){
            Debug.Log($"Obstacle hit! {other.gameObject}");
            ScrollerMiddlemanSO.damageObject?.Invoke(other.gameObject);
        }
        Destroy(this.gameObject);
    } */

    private void FixedUpdate() {
        float movement = pos.position.y + transform.up.y * Time.fixedDeltaTime * speed;
        gameObject.transform.position = new Vector3(transform.position.x , movement,0);
        lifeTime -= Time.fixedDeltaTime;
        if(lifeTime <= 0){
            Destroy(this.gameObject);
        }
    }
}