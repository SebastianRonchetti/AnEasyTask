using UnityEngine;
using TMPro;
using System;
public class LocalManagerScrollerScene : MonoBehaviour {
    int points;
    float activeTimer;
    [SerializeField]int lowestSpeed, highestSpeed;
    
    private void Awake() {
        ManagerToOutMiddle.unloadLevel += unloadLevel;
        ManagerMiddleman._onKeyPressAction += commandPause;
        ManagerMiddleman.onSceneLoaded?.Invoke();
    }

    private void Update() {
        if(Time.timeScale == 0){
            ScrollerMiddlemanSO.passCurrentTimer?.Invoke(0);
            return;
        }
        activeTimer += Time.deltaTime;
        float passedTimer = Mathf.RoundToInt(activeTimer % 60)/30;
        if(passedTimer > highestSpeed) {passedTimer = highestSpeed;}
        if(passedTimer < lowestSpeed) {passedTimer = lowestSpeed;}
        ScrollerMiddlemanSO.passCurrentTimer?.Invoke(passedTimer);
    }

    void commandPause(KeyCode _command){
        if(_command == KeyCode.M){
            TempMiddleman.pauseGame?.Invoke();
        }
    }

    void unloadLevel(){
        ManagerToOutMiddle.unloadLevel -= unloadLevel;
        ManagerToOutMiddle.backToWork?.Invoke();
    }
}