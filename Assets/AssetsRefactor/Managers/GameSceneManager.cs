using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : SingletonClass<GameSceneManager> {
    Scene _controlScene, activeScene, nextScene;
    Scene[] scenes;
    int succesfulUnsubscribed;

    private void Awake() {
        scenes = new Scene[3];
        _instantiate();
        _controlScene = SceneManager.GetSceneByName("BackgroundRun");
        scenes[0] = _controlScene;
        scenes[1] = SceneManager.GetSceneByName("workScene");
        scenes[2] = SceneManager.GetSceneByName("dinosaurScene");
        scenes[3] = SceneManager.GetSceneByName("collectorScene");
    }

    private void Start() {
        //load scene additive (working Scene)
    }

    public void changeScene(int _sceneCode){
        //sets new scene in additive form and unloads current scene
        nextScene = scenes[_sceneCode];
        ManagerMiddleman._unloadSceneAction?.Invoke();
    }
    void onUnsubscribeSuccesful(){
        int activeOperators = ManagerMiddleman._unloadSceneAction.GetInvocationList().Length;
        if(succesfulUnsubscribed >= activeOperators){
            unloadScene();
        }
    }

    void unloadScene() {
        SceneManager.UnloadSceneAsync(activeScene);
    }

    void loadScene() {
        //Load nextScene. current scene = nextScene.
    }

    void onSceneLoaded(){
        //event stablishing what scene is on
    }
    
}