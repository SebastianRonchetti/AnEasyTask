using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class localManagerMainMenu : MonoBehaviour
{
    private void Awake() {
        ManagerMiddleman.onSceneLoaded?.Invoke();
    }

    public void onPressStartBtn(){
        ManagerMiddleman.loadSceneByName?.Invoke("workScene");
    }
}
