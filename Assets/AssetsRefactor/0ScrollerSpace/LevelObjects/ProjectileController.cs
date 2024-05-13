using UnityEngine;

public class ProjectileController : MonoBehaviour {
    Transform pos;
    float speed = 15;

    private void Awake() {
        pos = gameObject.transform;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Obstacle")){
            Debug.Log($"Obstacle hit! {other.gameObject}");
            ScrollerMiddlemanSO.damageObject?.Invoke(other.gameObject);
        }
        Destroy(this.gameObject);
    }

    private void FixedUpdate() {
        float movement = pos.position.y + transform.up.y * Time.fixedDeltaTime * speed;
        gameObject.transform.position = new Vector3(transform.position.x , movement,0);
    }
}