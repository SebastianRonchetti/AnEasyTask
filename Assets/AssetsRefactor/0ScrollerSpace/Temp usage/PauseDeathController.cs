using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PauseDeathController : MonoBehaviour {
    [SerializeField] TMP_Text title, btnPlayTxt, btnWorkTxt;
    [SerializeField] Button btnPlay, btnWork;
    [SerializeField] GameObject background;
    [SerializeField] KeyCode pauseCommand = KeyCode.M;
    bool paused;

    private void Awake() {
        ScrollerMiddlemanSO.playerGameOver += gameOver;
        ManagerMiddleman._onKeyPressAction += onPauseGame;
        //TempMiddleman.pauseGame += onPauseGame;
        TempMiddleman.resumeGame += onResumeGame;
        TempMiddleman.backToWork += onGoBackToWork;
    }

    private void OnEnable() {
        btnPlayTxt = btnPlay.GetComponentInChildren<TMP_Text>();
        btnWorkTxt = btnWork.GetComponentInChildren<TMP_Text>();
        background.SetActive(false);
    }

    void OnDisable(){
        ScrollerMiddlemanSO.playerGameOver -= gameOver;
        //TempMiddleman.pauseGame -= onPauseGame;
        TempMiddleman.resumeGame -= onResumeGame;
        TempMiddleman.backToWork -= onGoBackToWork;
    }

    public void onPauseGame(KeyCode _comm){
        if(_comm == pauseCommand){
            background.gameObject.SetActive(true);
            btnPlayTxt.text = "Continue";
            btnWorkTxt.text = "Go back to work";
            title.text = "Pause";
            paused = true;
            Time.timeScale = 0;
        }
    }

    public void OnBtn1Click(){
        if(paused){
            paused = false;
            onResumeGame();
        } else {
            ManagerToOutMiddle.reload?.Invoke();
        }
    }

    void onResumeGame(){
        background.SetActive(false);
        Time.timeScale = 1;
    }

    public void onGoBackToWork(){
        Time.timeScale = 1;
        ManagerToOutMiddle.unloadLevel?.Invoke();
    }

    void gameOver(){
        btnPlayTxt.text = "Try again";
        btnWorkTxt.text = "Go back to work";
        title.text = "Game Over";
        background.SetActive(true);
        Time.timeScale = 0;
    }
}