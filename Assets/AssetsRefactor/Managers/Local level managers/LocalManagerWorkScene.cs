using UnityEngine;

public class LocalManagerWorkScene : MonoBehaviour {
    public void backToWork(){
        //awaitInput for concentration
    }

    public void playGames(){
        int random = Mathf.RoundToInt(Random.Range(3, 4));
        ManagerToOutMiddle.loadPlay(random);
    }
}