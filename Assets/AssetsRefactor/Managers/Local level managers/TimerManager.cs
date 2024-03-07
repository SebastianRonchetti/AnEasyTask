using UnityEngine;
using System;
using TMPro;
using System.Collections.Generic;
using Unity.Mathematics;

//Operator exclusive for the WORK scene. In charge of keeping track of the countdown and triggering time
// based events

class TimerManager : SingletonClass<TimerManager> {
    
    [SerializeField]float workProgressionBar = 0, workFinishedMark = 420f;
    [SerializeField] List<TimedEventSO> timedEvents;
    DialogueUI DUI;
    [SerializeField] TextMeshProUGUI timerObject;
    bool canConcentrate = true;
    public class onUpdateUIBar_eventArgs : EventArgs {
        public float currentAmount, maxAmount;
    }

    public void triggerTimedEvent_Test(TimedEventSO eventTest){
        canConcentrate = false;
        ManagerToOutMiddle.OnTimeEventTrigger?.Invoke(eventTest);
        DUI.ShowDialogue(eventTest.Dialogue);
    }

    private void Awake() {
        _instantiate();
        workProgressionBar = workFinishedMark;
        ManagerMiddleman.saveProgressBar(workProgressionBar);
    }

    private void OnEnable() {
        ManagerMiddleman.workStationConcentrating += keepTimerActive;
        //ManagerMiddleman.concentrationStopped += cantConcentrate;
        ManagerMiddleman.WaitForInput += WaitForInput;
        TestMiddleman.onTriggerThis += triggerTimedEvent_Test;
        workProgressionBar = ManagerMiddleman.loadProgress();
        ManagerToOutMiddle._updateUIProgressBarCurrentMax(workProgressionBar, workFinishedMark);
        DUI = DialogueUI.Instance;
    }
    private void OnDisable() {
        ManagerMiddleman.workStationConcentrating -= keepTimerActive;
        //ManagerMiddleman.concentrationStopped -= cantConcentrate;
        ManagerMiddleman.WaitForInput -= WaitForInput;
        ManagerMiddleman.saveProgressBar(workProgressionBar);
        resetTimeEventTriggers();
    }
    
    //Function which keeps the countdown going. Receives triggers via event activated with input by the user.
    void keepTimerActive(){
        workProgressionBar += 0;
        if(canConcentrate){
            if(workProgressionBar > 0){
                workProgressionBar -= Time.deltaTime;
                UpdateTimer(workProgressionBar);
                checkCurrentProgress();
                ManagerToOutMiddle._updateUIProgressBarCurrentMax?.Invoke(workProgressionBar, workFinishedMark);
            } else {
                ManagerMiddleman.WorkFinished?.Invoke();
            }
        }
    }

// updates the counter on screen
    void UpdateTimer(float currentTime){
        currentTime += 1;
        string _minutes = Mathf.FloorToInt(currentTime / 60).ToString();
        string _seconds = Mathf.FloorToInt(currentTime % 60).ToString();
        
        timerObject.text = string.Format($"T{_minutes}:{_seconds}");
    }
// Verifies current counter time against a list of time sensitive events and triggers the one that matches
// the time window.
    void checkCurrentProgress(){
        int closestWholeNumber = (int) Mathf.Round(workProgressionBar);
        foreach(TimedEventSO timedEvent in timedEvents){
            for(int i = 0; i < timedEvent.TimeMark.Length; i++){
                if(timedEvent.TimeMark[i].TimeMark == closestWholeNumber && !timedEvent.TimeMark[i].Triggered){
                    canConcentrate = false;
                    timedEvent.TimeMark[i].trigger();
                    ManagerToOutMiddle.OnTimeEventTrigger?.Invoke(timedEvent);
                    DUI.ShowDialogue(timedEvent.Dialogue);
                }
            }
        }
    }

    void resetTimeEventTriggers(){
        foreach(TimedEventSO timedEvent in timedEvents){
            for(int i = 0; i < timedEvent.TimeMark.Length; i++){
                timedEvent.TimeMark[i].disableTrigger();
            }
        }
    }

// 
    /* void cantConcentrate(KeyCode a){
        if(canConcentrate){
            canConcentrate = false;
        }
        float rnd = UnityEngine.Random.Range(0,100);
        int level;
        if(rnd < 51){
            level = 3; // dinosaur
        } else {
            level = 4; // collector
        }
        ManagerToOutMiddle.loadPlay?.Invoke(level);
    } */
    
    void WaitForInput(){
        canConcentrate = true;
    }
}