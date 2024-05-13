using UnityEngine;

public class LocalManagerWorkScene : MonoBehaviour {
    public void backToWork(){
        //awaitInput for concentration
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