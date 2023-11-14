using UnityEngine.SceneManagement;

public class GameSceneManager : SingletonClass<GameSceneManager> {
    sceneCodes _controlScene, activeScene, nextScene;
    public sceneCodes[] scenes;

    private void Awake() {
        _instantiate();
        scenes = new sceneCodes[4];
        ManagerMiddleman.loadSceneByName += changeScene;
        
        for(int i = 0; i < scenes.Length; i++){
            string pathToScene = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(pathToScene);
            if(sceneName.Length <= 0){
                return;
            } else {
                scenes[i] = new sceneCodes(i, sceneName);
            }
        }
        
        _controlScene = scenes[0];
        if(activeScene != scenes[1]){
            changeScene("workScene");
        }
    }

    private void Start() {
        ManagerToOutMiddle.backToWork += backToWork;
        ManagerToOutMiddle.loadPlay += playGame;
    }

    void backToWork(){
        changeScene(scenes[1].getName());
    }

    void playGame(int game){
        changeScene(scenes[game].getName());
    }

    public void changeScene(string sceneName){
        for(int i = 1; i < scenes.Length; i++){
            if(scenes[i].getName() == sceneName){
                nextScene = scenes[i];
                if(activeScene != null)
                {
                    SceneManager.UnloadSceneAsync(activeScene.getCode());
                }
                SceneManager.LoadSceneAsync(nextScene.getCode(), LoadSceneMode.Additive);
                activeScene = nextScene;
                ManagerMiddleman._loadSceneAction?.Invoke(activeScene.getName());
            }
        }

        /* foreach(Scene scene in scenes){
            if(scene.name == sceneName){
                nextScene = scene;
                if(activeScene != null)
                {
                    SceneManager.UnloadSceneAsync(activeScene);
                }
                SceneManager.LoadSceneAsync(nextScene.buildIndex, LoadSceneMode.Additive);
                activeScene = nextScene;
                ManagerMiddleman._loadSceneAction(activeScene.name);
                Debug.Log(scene);
            }
        } */
    }
/* 
    public void changeScene(int _sceneCode){
        //sets new scene in additive form and unloads current scene
        nextScene = scenes[_sceneCode];
        SceneManager.LoadSceneAsync(nextScene.buildIndex, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(activeScene);
        activeScene = nextScene;
        ManagerMiddleman._loadSceneAction(activeScene.name);
        Debug.Log(scenes[_sceneCode]);
    } */

}
public class sceneCodes{
    int code;
    string sceneName;

    public sceneCodes(int _code, string _sceneName){
        this.code = _code;
        sceneName = _sceneName;
    }

    public string getName(){
        return sceneName;
    }

    public int getCode(){
        return code;
    }
}