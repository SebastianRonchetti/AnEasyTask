using System;
using UnityEngine;

public class ManagerMiddleman : ScriptableObject {
    static float progressBar;
    static int timesPrompted;
    public static Action _loadWorkSceneAction, WaitForInput, WorkFinished;          //
    public static Action _unloadWorkSceneAction;        //
    public static Action<string> _loadSceneAction;
    public static Action _unloadSceneAction;
    public static Action<KeyCode, float> _onKeyPressOrHoldAction;
    public static Action _finishedUnsubscribing;
    public static Action<DialogueUI> _setManagerReference;
    public static Action<float, float> AxisRaw;

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