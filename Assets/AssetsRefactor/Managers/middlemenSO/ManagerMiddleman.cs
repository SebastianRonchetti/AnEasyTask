using System;
using UnityEngine;

public class ManagerMiddleman : ScriptableObject {
    static float progressBar;
    static int timesPrompted;
    public static Action _loadWorkSceneAction, WaitForInput, WorkFinished;
    public static Action<string> _loadSceneAction;
    public static Action<int> loadSceneByCode;
    public static Action<string> loadSceneByName;
    public static Action<KeyCode> _onKeyPressOrHoldAction;
    public static Action<DialogueUI> _setManagerReference;
    public static Action<float, float> AxisRawHorizontalVertical;
    public static Action workStationConcentrating;
    public static Action<GameObject> setPlayerForOperator;
    public static Action<KeyCode> concentrationStopped;

    public static void saveProgressBar(float progress) {
        progressBar = progress;
    }

    public static float loadProgress(){
        return progressBar;
    }

    public static void setTimesPrompted(int _prompts) {
        timesPrompted = _prompts;
    }

    public static int loadPrmpts(){
        return timesPrompted;
    }

    public void executeLoadSceneAction(string sceneName){
        
    }
}