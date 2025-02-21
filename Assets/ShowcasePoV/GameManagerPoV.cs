using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerPoV : SingletonClass<GameManagerPoV>
{
    [SerializeField]TextMeshProUGUI timerObject;
    [SerializeField]float workProgressionBar = 0, workFinishedMark = 420f; //420
    int timesConcentratePrompted = 0;
    [SerializeField]GameObject dialoguePlay;
    public static event EventHandler<EventArgs> awaitInput;
    public static event EventHandler<onUpdateUIBar_eventArgs> onUpdateUIBar;
    public class onUpdateUIBar_eventArgs : EventArgs {
        public float currentAmount, maxAmount;
    }
    // Start is called before the first frame update

    private void Awake() {
        this._instantiate();
    }

    private void OnDestroy() {
        PlayerManagerPoV.onFocus -= isConcentrating;
    }

    private void OnEnable() {
        workProgressionBar = workFinishedMark;
        PlayerManagerPoV.onFocus += isConcentrating;
        
        dialoguePlay.SetActive(false);

        awaitInput?.Invoke(this, new EventArgs());
    }

    public void onPlayAGame(bool _play){
        if(_play){
            SceneManager.LoadSceneAsync("SampleScene");
        } else {
            dialoguePlay.SetActive(false);
            awaitInput?.Invoke(this, new EventArgs());
        }
    }

    void isConcentrating(object sender, EventArgs e){
        workProgressionBar += 0;

        if(workProgressionBar > 0){
            workProgressionBar -= Time.deltaTime;
            onUpdateUIBar?.Invoke(this, new onUpdateUIBar_eventArgs 
                {
                    currentAmount = workProgressionBar, 
                    maxAmount = workFinishedMark
                });
            UpdateTimer(workProgressionBar);
            if(workProgressionBar < 410 && 409 < workProgressionBar && timesConcentratePrompted == 0){
                dialoguePlay.SetActive(true);
            } else if(workProgressionBar < 391 && 390 > workProgressionBar && timesConcentratePrompted == 1){
            }
        }
    }

    void UpdateTimer(float currentTime){
        currentTime += 1;
        string _minutes = Mathf.FloorToInt(currentTime / 60).ToString();
        string _seconds = Mathf.FloorToInt(currentTime % 60).ToString();

        timerObject.text = string.Format($"T{_minutes}:{_seconds}");
    }
}
