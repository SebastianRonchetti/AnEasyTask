using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class DialogueUI : SingletonClass<DialogueUI> {
    [SerializeField] private GameObject dialogueBox, textLabelObject;
    [SerializeField] private TMP_Text textLabel;
    ResponseHandler _responseHandler;
    TypeWritterEffect _typeWritterEffect;
    [SerializeField] List<DialogueSO> _listOfAllDialogues;
    public bool IsOpen {get; private set;}

    private void Awake() {
        _instantiate();
        if(!TryGetComponent<TypeWritterEffect>(out _typeWritterEffect)){
            Destroy(this.gameObject);
        }
    }

    private void Start() {
        textLabel = textLabelObject.GetComponent<TMP_Text>();
        _responseHandler = GetComponent<ResponseHandler>();
        ManagerMiddleman._setManagerReference?.Invoke(this);
        CloseDialogueBox();
    }

// Adds response events based on the array passed on activation
    public void AddResponseEvents(ResponseEvent[] _responseEvents) {
        _responseHandler.addResponseEvents(_responseEvents);
    }

    public void ShowDialogue(DialogueObjectSO _dialogueToDisplay) {
        IsOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(stepThroughDialogue(_dialogueToDisplay));
    }

//Function that displays each dialogueSO
    IEnumerator stepThroughDialogue(DialogueObjectSO _dialogueToDisplay) {
        for(int i = 0; i < _dialogueToDisplay.Dialogue.Length; i++){
            string dialogue = _dialogueToDisplay.Dialogue[i];
            
            yield return RunningTypingEffect(dialogue);

            //if the current dialogue being displayed is the last one stop the forloop
            if(i == _dialogueToDisplay.Dialogue.Length - 1 && _dialogueToDisplay.HasResponses){
                break;
            };

            //yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.X));
        }

        //If the dialogue has any attached responses display them or wait to close the box
        if(_dialogueToDisplay.HasResponses){
            _responseHandler.ShowResponses(_dialogueToDisplay.Responses);
        } else {
            CloseDialogueBox();
        }
    }

    void OpenDialogueBox(int _dialogueID){
        DialogueSO _chosenDialogue;
        dialogueBox.SetActive(true);
        foreach (DialogueSO fullDialogue in _listOfAllDialogues) {
            if(fullDialogue._DialogueID == _dialogueID){
                _chosenDialogue = fullDialogue;
                ShowDialogue(_chosenDialogue.Dialogue[0]);
                break;
            }
        }
    }

    public void CloseDialogueBox() {
        IsOpen = false;
        textLabel.text = string.Empty;
        dialogueBox.SetActive(false);
    }

//Displays each substring progressively and independently in the dialogue UI
    IEnumerator RunningTypingEffect(string dialogue) {
        _typeWritterEffect.Run(dialogue, textLabel);
        while(_typeWritterEffect.isRunning){
            if(Input.GetKey(KeyCode.E)){
                _typeWritterEffect.Stop();
            }
            yield return null;
        }
    }
}