using System;
using UnityEngine;

public class ManagerMiddleman : ScriptableObject {
    static float progressBar;
    public static Action _loadWorkSceneAction;          //
    public static Action _unloadWorkSceneAction;        //
    public static Action<string> _loadSceneAction;
    public static Action _unloadSceneAction;
    public static Action<KeyCode, float> _onKeyPressOrHoldAction;
    public static Action _finishedUnsubscribing;

    public static void saveProgressBar(float progress) {
        progressBar = progress;
    }

    public static float loadProgress(){
        return progressBar;
    }
}