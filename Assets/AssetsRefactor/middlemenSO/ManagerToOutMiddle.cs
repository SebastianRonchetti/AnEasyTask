using System;
using UnityEngine;

//This script operates as a middleman to store general events in these events can be called or subscribed by
// any and all scripts.

public class ManagerToOutMiddle : ScriptableObject {
    static GameObject _playerOnScene;
    public static GameObject PlayerOnScene => _playerOnScene;
    public static Action<float, float> _updateUIProgressBarCurrentMax; // fill amount, max amount
    public static Action<GameObject> setPlayerOnScene;

    public static Action backToWork;
    public static Action reload;
    public static Action<int> loadPlay;
    public static Action workSceneConcentrateAwaitInput;
    public static Action<TimedEventSO> OnTimeEventTrigger;
    public static Action<ArticleSO> OnShowArticleAction;

    public static void executeLoadPlay(int game){
        loadPlay?.Invoke(game);
    }
}