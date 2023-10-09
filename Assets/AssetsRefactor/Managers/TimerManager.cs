using UnityEngine;
using System;
using System.Collections;
using TMPro;
using System.Collections.Generic;

class TimerManager : SingletonClass<TimerManager> {
    
    [SerializeField]float workProgressionBar = 0, workFinishedMark = 420f;
    [SerializeField] List<TimedEventSO> timedEvents;
    DialogueUI DUI;
    bool _concentratePromptable;
    [SerializeField] TextMeshProUGUI timerObject;
    public class onUpdateUIBar_eventArgs : EventArgs {
        public float currentAmount, maxAmount;
    }

    private void Awake() {
        _instantiate();
        workProgressionBar = workFinishedMark;
        ManagerMiddleman.saveProgressBar(workProgressionBar);
    }

    private void OnEnable() {
        ManagerMiddleman.workStationConcentrating += keepTimerActive;
        workProgressionBar = ManagerMiddleman.loadProgress();
        ManagerToOutMiddle._updateUIProgressBarCurrentMax(workProgressionBar, workFinishedMark);
        DUI = DialogueUI.Instance;
    }
    private void OnDisable() {
        ManagerMiddleman.workStationConcentrating -= keepTimerActive;
        ManagerMiddleman.saveProgressBar(workProgressionBar);
    }
    
    void keepTimerActive(){
        workProgressionBar += 0;

        if(workProgressionBar > 0){
            workProgressionBar -= Time.deltaTime;
            UpdateTimer(workProgressionBar);
            checkCurrentProgress();
            ManagerToOutMiddle._updateUIProgressBarCurrentMax?.Invoke(workProgressionBar, workFinishedMark);
        } else {
            ManagerMiddleman.WorkFinished?.Invoke();
        }
    }

    void UpdateTimer(float currentTime){
        currentTime += 1;
        string _minutes = Mathf.FloorToInt(currentTime / 60).ToString();
        string _seconds = Mathf.FloorToInt(currentTime % 60).ToString();
        
        timerObject.text = string.Format($"T{_minutes}:{_seconds}");
    }

    void checkCurrentProgress(){
        int closestWholeNumber = (int) Mathf.Round(workProgressionBar);
        foreach(TimedEventSO timedEvent in timedEvents){
            if(timedEvent.TimeMark == closestWholeNumber && _concentratePromptable){
                _concentratePromptable = false;
                StartCoroutine(concentrateCooldown());
                DUI.ShowDialogue(timedEvent.Dialogue);
            }
        }
    }

    IEnumerator concentrateCooldown(){
        yield return new WaitForSeconds(2f);
        _concentratePromptable = true;
    }
}