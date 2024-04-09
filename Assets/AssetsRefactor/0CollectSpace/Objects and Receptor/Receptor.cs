using UnityEngine;
public class Receptor : MonoBehaviour
{
    [SerializeField] LayerMask objectsToPickUp;
    [SerializeField] string _pickableTag;
    [SerializeField] public bool complete;
    [SerializeField] Transform dropPoint;
    [SerializeField] float pickupRadius;

    private void Start() {
        CollectorLocalMiddlemanSO.AddReceptorToManagerList?.Invoke(this);
    }
    private void Update() {
        Collider2D _col = Physics2D.OverlapCircle(dropPoint.position, pickupRadius, objectsToPickUp);
        if(_col != null){
            if(_col.gameObject.CompareTag(_pickableTag)){
                Destroy(_col.gameObject);
                CollectorLocalMiddlemanSO.itemStored?.Invoke();
            }
        }
    }
    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(dropPoint.position, pickupRadius);
    }
}
