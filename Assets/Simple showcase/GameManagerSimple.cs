using UnityEngine;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerSimple : SingletonClass<GameManagerSimple> {
    //taria bueno una maquina de estados con SO en vez de lo que hice aca eh

    [SerializeField]float workProgressionBar = 0, workFinishedMark = 420f;
    [SerializeField]List<Receptor> listOfReceptors;
    [SerializeField]PlayerManagerSimple player;
    [SerializeField]GameObject Dialogue;
    int timesConcentratePrompted = 0;
    public event EventHandler<EventArgs> awaitInput;
    bool canceladorAsync;

    public void Awake() {
        this._instantiate();
        workProgressionBar = workFinishedMark;
    }

    private void Start() {/* 
        PlayerManagerSimple.onFocusing += isConcentrating;
        player = PlayerManagerSimple.Instance;
        bt1Text = button1.GetComponentInChildren<TextMeshProUGUI>();
        bt2Text = button2.GetComponentInChildren<TextMeshProUGUI>();
        onWork(); */
    }

    private void OnEnable() {
        Dialogue.SetActive(false);
    }
    private void Update() {
        
    }

    public void addToList(Receptor r){
        listOfReceptors.Add(r);
        r.onComplete += onChoreFulfilled;
    }

    void onChoreFulfilled(object sender, EventArgs e){
        int totalReceptors = listOfReceptors.Count, completedReceptors = 0;
        foreach(Receptor r in listOfReceptors){
            if(r.complete){
                completedReceptors ++;
                if(completedReceptors >= totalReceptors){
                    Dialogue.SetActive(true);
                }
            } else {
                break;
            }
        }
    }

    public void onPlayOrWork(bool _play) {
        if(_play) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } else {
            SceneManager.LoadSceneAsync("PoVDesktopVersion");
        }
    }
    /*void isConcentrating(object sender, EventArgs e){
        workProgressionBar += 0;

        if(workProgressionBar > 0){
            workProgressionBar -= Time.deltaTime;
            UpdateTimer(workProgressionBar);
            //Debug.Log("Me concentro hmmmmmmm");
            if(workProgressionBar < 410 && 409 < workProgressionBar && timesConcentratePrompted == 0){
                    promptConcentrate();
            } else if(workProgressionBar < 391 && 390 > workProgressionBar && timesConcentratePrompted == 1){
                    promptConcentrate();
            }
        } else {
            //work done
        }
    }

     void UpdateTimer(float currentTime){
        currentTime += 1;
        string _minutes = Mathf.FloorToInt(currentTime / 60).ToString();
        string _seconds = Mathf.FloorToInt(currentTime % 60).ToString();

        timerObject.text = string.Format($"T{_minutes}:{_seconds}");
    }

    

    void completeChore(object sender, EventArgs e){
        //if(sender == activeReceptor){}
        promptChoice();
    }

    void promptConcentrate() {
        switch(timesConcentratePrompted){
            case 0:
                setButton(button1, 3, true);
                bt1Text.text = "Concentrarse";
                canceladorAsync = false;
                buttonNotPushed(40, false);
                timesConcentratePrompted ++;
                break;
            case 1:
                setButton(button1, 3, true);
                bt1Text.text = "Concentrarse";
                canceladorAsync = false;
                buttonNotPushed(20, false);
                timesConcentratePrompted ++;
                break;
            case 2:
                setButton(button2, 3, true);
                bt1Text.text = "no Concentrarse";
                canceladorAsync = false;
                buttonNotPushed(10, true);
                timesConcentratePrompted ++;
                break;
            case 3:
                setButton(button1, 3, true);
                bt1Text.text = "Concentrarse";
                canceladorAsync = false;
                timesConcentratePrompted ++;
                break;
            case 4:
                setButton(button1, 3, true);
                bt1Text.text = "Distraerse";
                canceladorAsync = false;
                timesConcentratePrompted ++;
                break;
            case 5:
                timesConcentratePrompted ++;
                bt1Text.text = "Concentrarsen't";
                break;           
        }
    }

    void promptChoice() {
        setButton(button1, 1, true);
        setButton(button2, 2, true);
        bt1Text.text = "Work";
        bt2Text.text = "keep choring";
    }

    void setButton(GameObject _button, int buttonPosition, bool activate) {
        _button.SetActive(activate);
        if(_button.activeSelf == true){
            switch(buttonPosition) {
                case 1:
                _button.transform.position = buttonPosition1.position;
                    break;
                case 2:
                _button.transform.position = buttonPosition2.position;
                    break;
                case 3:
                _button.transform.position = buttonPosition3.position;
                    break;
            }
        }
    }

    public void onButtonPress(bool choice){
        if(choice){
            onWork();
        } else {
            onChoring();
        }

        if(!canceladorAsync) {
            canceladorAsync = true;
        }
    }

    void onWork(){
        setButton(button1, 1, false);
        setButton(button2, 2, false);
        awaitInput?.Invoke(this, new EventArgs());
        player.gameObject.transform.position = essayWritingStation.transform.position;
    }

    void onChoring() {
        setButton(button1, 1, false);
        setButton(button2, 2, false);        
        player.stopConcentrating();
    }

    void cancelarAsync(){
        canceladorAsync = true;
    }

    async void buttonNotPushed(float duration, bool canConcentrate) { 
        var end = duration +  Time.time;
        while(Time.time > end){
            if(canceladorAsync){
                break;
            }

            if(canConcentrate) {
                onButtonPress(true);
            } else {
                onButtonPress(false);
            }
            canceladorAsync = true;
            await Task.Yield();
        }
    }*/
}