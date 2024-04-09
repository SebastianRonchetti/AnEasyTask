using UnityEngine;

public class InputTriggered_Test : MonoBehaviour {
    [SerializeField] private TimedEventSO _timedEventTest;
    public TimedEventSO TimedEventTest => _timedEventTest;
    private void Update() {
        if(Input.GetKeyDown(KeyCode.J)){
            TestMiddleman.TriggerThis?.Invoke(_timedEventTest);
        }
    }
}