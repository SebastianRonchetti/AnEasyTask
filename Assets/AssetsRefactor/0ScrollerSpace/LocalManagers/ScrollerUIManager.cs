using UnityEngine;
using System;
using TMPro;

public class ScrollerUIManager : MonoBehaviour {
    
    TextMeshProUGUI pointDisplay, timerDisplay;
    private void Awake() {
        ScrollerMiddlemanSO.UnloadSubscriptions += unload;
        ScrollerMiddlemanSO.displayHealth += displayHealth;
        ScrollerMiddlemanSO.passCurrentTimer += displayTimer;
    }

    void unload(){
        ScrollerMiddlemanSO.displayHealth -= displayHealth;
        ScrollerMiddlemanSO.UnloadSubscriptions -= unload;
    }

    void displayTimer(float _currentTime){
        string _minutes = Mathf.FloorToInt(_currentTime / 60).ToString();
        string _seconds = Mathf.FloorToInt(_currentTime % 60).ToString();
        timerDisplay.text = string.Format($"{_minutes}:{_seconds}");
    }

    void displayPoints(){
        //pointDisplay.text = points.ToString();
    }

    void displayHealth(int _currentHealth){

    }
}