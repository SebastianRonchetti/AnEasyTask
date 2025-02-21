using UnityEngine;

public class InputTriggered_Test : MonoBehaviour {
    [SerializeField] private TimedEventSO _timedEventTest;
    public TimedEventSO TimedEventTest => _timedEventTest;
    /* private void Update() {
        if(Input.GetKeyDown(KeyCode.J)){
            TestMiddleman.TriggerThis?.Invoke(_timedEventTest);
        }

        // N de Navecitas
        if(Input.GetKeyDown(KeyCode.N)){
            ManagerMiddleman.loadSceneByName("InfiniteScroller");
        }

        //B de Boblin el goblin
        if(Input.GetKeyDown(KeyCode.B)){
            Debug.Log("anda a cagar");
            ManagerMiddleman.loadSceneByName("collectorScene");
        }
    } */
}