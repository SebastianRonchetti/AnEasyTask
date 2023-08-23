using UnityEngine;

public class TriggerSO : ScriptableObject {
    public float timerMark;
    public int timesPrompted;
    public TriggeredActionSO triggeredActionSO;

    public void testTrigger(float time, int triggers) {
        if(time <= timerMark){
            if(triggers == timesPrompted){
                triggeredActionSO._invokeAction();
            }
        }
    }
}