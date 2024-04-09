using UnityEngine;

public class ProjectileController : MonoBehaviour {
    Transform pos;
    float speed;
    Rigidbody2D rb;
    Collider2D col;

    private void Awake() {
        pos = gameObject.transform;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.TryGetComponent(out ObstacleController obstacleController)){
            obstacleController.damage();
        }
        Destroy(this);
    }

    private void Update() {
        pos.position = transform.forward * Time.deltaTime * speed;
    }
}