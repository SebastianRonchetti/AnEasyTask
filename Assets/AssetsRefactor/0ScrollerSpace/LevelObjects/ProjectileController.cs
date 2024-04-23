using UnityEngine;

public class ProjectileController : MonoBehaviour {
    Transform pos;
    float speed;
    Collider2D col;

    private void Awake() {
        pos = gameObject.transform;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        ScrollerMiddlemanSO.damageObject?.Invoke(other.gameObject);
        Destroy(this);
    }

    private void Update() {
        pos.position = transform.forward * Time.deltaTime * speed;
    }
}