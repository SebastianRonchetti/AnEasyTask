using UnityEngine;
using System;

//
public class DialogueResponseEvent : MonoBehaviour {
    [SerializeField] DialogueObjectSO dialogueObject;
    [SerializeField] ResponseEvent[] _events;
    [SerializeField] TimedEventSO _relatedTimeEvent;
    public ResponseEvent[] Events => _events;
    public DialogueObjectSO dialogueObjectSO => dialogueObject;
    private void Awake() {
        ManagerToOutMiddle.OnTimeEventTrigger += OnRelatedDialogueTriggered;
    }

    void OnRelatedDialogueTriggered(TimedEventSO triggeredEvent){
        if(triggeredEvent == _relatedTimeEvent){
            DialogueUI.Instance.AddResponseEvents(Events);
        }
    }
//
    public void OnValidate() {
        //Checks that the dialogue object contains all the necesary data, on validation failure the excecution
        //stops.
        if(dialogueObject == null) return;
        if(dialogueObject.Responses == null) return;

        // Checks that the dialogueObject contains the correct amount of events based on the amount of responses
        if(_events != null && _events.Length == dialogueObject.Responses.Length) return;

        //Creates or resizes an array of response events based on the amount of responses a dialogue has
        if(_events == null) {
            _events = new ResponseEvent[dialogueObject.Responses.Length];
        } else {
            Array.Resize(ref _events, dialogueObject.Responses.Length);
        }

        //Checks each response event is correctly correlated with its response equivalent
        for(int i = 0; i < dialogueObject.Responses.Length; i++) {
            Response response = dialogueObject.Responses[i];

            //if an existing event doesnt exist at a position. Create a new one and name it after the
            //response name at the same position in the response list from the dialogue object
            //then stop the function.
            if(_events[i] != null) {
                _events[i].name = response.responseText;
                continue;
            }

            //if an event doesnt exist, create a new one and name it after the equivalent response at the
            //response list
            _events[i] = new ResponseEvent(){name = response.responseText};
        }
    }
}