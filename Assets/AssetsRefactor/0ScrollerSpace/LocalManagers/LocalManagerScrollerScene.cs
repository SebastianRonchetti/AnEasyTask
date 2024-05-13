using UnityEngine;
using TMPro;
using System;
public class LocalManagerScrollerScene : MonoBehaviour {
    int points;
    float activeTimer;
    int lowestSpeed, highestSpeed;
    bool stoppedOrPaused = false;
    
    private void Awake() {
        ManagerToOutMiddle.unloadLevel += unloadLevel;    
    }

    private void Update() {
        if(!stoppedOrPaused){
            activeTimer += Time.deltaTime;
            ScrollerMiddlemanSO.passCurrentTimer?.Invoke(activeTimer);
        }
    }

    void stopGame(){
        stoppedOrPaused = true;
    }
    void pauseGame(){
        stoppedOrPaused = true;
    }

    void resume(){
        stoppedOrPaused = false;
    }

    void unloadLevel(){
        ScrollerMiddlemanSO.UnloadSubscriptions?.Invoke();
        ManagerToOutMiddle.unloadLevel -= unloadLevel;
    }
}