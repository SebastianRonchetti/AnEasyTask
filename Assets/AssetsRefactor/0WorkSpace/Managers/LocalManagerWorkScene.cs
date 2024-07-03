using UnityEngine;

public class LocalManagerWorkScene : MonoBehaviour {

    private void Awake() {
        ManagerMiddleman.onSceneLoaded?.Invoke();
    }
    private void OnEnable() {
        backToWork();
    }

    public void backToWork(){
        ManagerMiddleman.WaitForInput?.Invoke();
    }

    public void playGames(){
        int random = Mathf.RoundToInt(Random.Range(3, 4));
        ManagerToOutMiddle.loadPlay?.Invoke(random);
    }

    public void concentrateAwaitInput(){
        ManagerMiddleman.WaitForInput?.Invoke();
    }

    public void test(){

    }
}