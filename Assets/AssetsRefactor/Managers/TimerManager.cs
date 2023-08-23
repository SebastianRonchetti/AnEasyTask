using UnityEngine;
using System;
using System.Collections;
using TMPro;

class TimerManager : SingletonClass<TimerManager> {
    
    [SerializeField]float workProgressionBar = 0, workFinishedMark = 420f;
    int timesConcentratePrompted = 0;
    bool _concentratePromptable;
    [SerializeField] TextMeshProUGUI timerObject;

    private void Awake() {
        _instantiate();
    }

    private void OnEnable() {
        PlayerManagerSimple.onFocusing += keepTimerActive;
        workProgressionBar = ManagerMiddleman.loadProgress();
    }
    private void OnDisable() {
        PlayerManagerSimple.onFocusing -= keepTimerActive;
        ManagerMiddleman.saveProgressBar(workProgressionBar);
    }
    
    void keepTimerActive(object sender, EventArgs e){
        workProgressionBar += 0;

        if(workProgressionBar > 0){
            workProgressionBar -= Time.deltaTime;
            UpdateTimer(workProgressionBar);
            
        } else {
            //work done
        }
    }

    void UpdateTimer(float currentTime){
        currentTime += 1;
        string _minutes = Mathf.FloorToInt(currentTime / 60).ToString();
        string _seconds = Mathf.FloorToInt(currentTime % 60).ToString();
    }

    void checkCurrentProgress(){
        int closestWholeNumber = (int) Mathf.Round(workProgressionBar);
        if(closestWholeNumber == 410 && timesConcentratePrompted == 0){
            promptConcentrate();
        } else if(closestWholeNumber == 390 && timesConcentratePrompted == 1){
            promptConcentrate();
        } else if(closestWholeNumber == 330 && timesConcentratePrompted == 2){
            promptConcentrate();
        } else if(closestWholeNumber == 270 && timesConcentratePrompted == 3){
            promptConcentrate();
        } else if(closestWholeNumber == 210 && timesConcentratePrompted == 4){
            promptConcentrate();
        } else if(closestWholeNumber == 150 && timesConcentratePrompted == 5){
            promptConcentrate();
        } else if(closestWholeNumber == 90 && timesConcentratePrompted == 6){
            promptConcentrate();
        } else if(closestWholeNumber == 30 && timesConcentratePrompted == 7){
            promptConcentrate();
        }
    }

    void promptConcentrate(){
        if(_concentratePromptable) {
            _concentratePromptable = false;
            timesConcentratePrompted ++;
            //prompt event or action that triggers concentration (on game master?)
        }
    }

    void loadWorkScene (float _storedWork){
        workProgressionBar = _storedWork;
    }

    IEnumerator concentrateCooldown(){
        yield return new WaitForSeconds(2f);
        _concentratePromptable = true;
    }
}