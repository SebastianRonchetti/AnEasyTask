using UnityEngine;
public class PickableItem : MonoBehaviour
{
    bool _isBeingHeld;
    public bool Held => _isBeingHeld;

    private void Start() {
        CollectorLocalMiddlemanSO.AddItemToReceptorList?.Invoke(this);
    }
    public void onInteract(){
        if(!_isBeingHeld) {
            _isBeingHeld = true;
        } else {
            _isBeingHeld = false;
        }
    }
}