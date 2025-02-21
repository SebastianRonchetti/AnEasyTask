using UnityEngine;
public class PickableItem : MonoBehaviour
{
    [SerializeField] bool _isBeingHeld = false;
    public bool Held => _isBeingHeld;

    private void Start() {
        CollectorLocalMiddlemanSO.AddItemToReceptorList?.Invoke(this);
    }
    public void onPick(){
        _isBeingHeld = true;
    }

    public void onDrop(){
        _isBeingHeld = false;
    }
}