using System;
using UnityEngine;

public class ManagerMiddleman : ScriptableObject {
    static float progressBar = -1;
    static int timesPrompted;
    public static Action _loadWorkSceneAction, WaitForInput, WorkFinished, workStationConcentrating,
            onSceneLoaded;
    public static Action<string> _loadSceneAction;
    public static Action<string> loadSceneByName;
    public static Action<KeyCode> _onKeyPressOrHoldAction, _onKeyPressAction, _onKeyHoldAction, concentrationStopped;
    public static Action<DialogueUI> _setManagerReference;
    public static Action<float, float> AxisRawHorizontalVertical;
    public static Action<GameObject> setPlayerForOperator;
    public static Action _tempSaveProgressCommand;

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
}