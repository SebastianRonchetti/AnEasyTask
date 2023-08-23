using UnityEngine;
using System;

/* class TimerManager : SingletonClass<TimerManager> {
    
    [SerializeField]float workProgressionBar = 0, workFinishedMark = 420f;

    private void Awake() {
        this._instantiate();
    }

    private void OnEnable() {
        PlayerManagerSimple.onFocusing += keepTimerActive;
    }
    private void OnDisable() {
        PlayerManagerSimple.onFocusing -= keepTimerActive;

    }
    
    void keepTimerActive(object sender, EventArgs e){
        workProgressionBar += 0;

        if(workProgressionBar > 0){
            workProgressionBar -= Time.deltaTime;
            UpdateTimer(workProgressionBar);
            /* if(workProgressionBar < 410 && 409 < workProgressionBar && timesConcentratePrompted == 0){
                    promptConcentrate();
            } else if(workProgressionBar < 391 && 390 > workProgressionBar && timesConcentratePrompted == 1){
                    promptConcentrate();
            } 
        } else {
            //work done
        }
    }

    void UpdateTimer(float currentTime){
        currentTime += 1;
        string _minutes = Mathf.FloorToInt(currentTime / 60).ToString();
        string _seconds = Mathf.FloorToInt(currentTime % 60).ToString();

        
    }
} */