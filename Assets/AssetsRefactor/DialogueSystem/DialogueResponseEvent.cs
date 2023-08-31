using UnityEngine;
using System;
public class DialogueResponseEvent : MonoBehaviour {
    [SerializeField] DialogueObjectSO dialogueObject;
    [SerializeField] ResponseEvent[] _events;
    public ResponseEvent[] Events => _events;
    public DialogueObjectSO dialogueObjectSO => dialogueObject;

    public void onValidate() {
        if(dialogueObject == null) return;
        if(dialogueObject.Responses == null) return;
        if(_events != null && _events.Length == dialogueObject.Responses.Length) return;

        if(_events == null) {
            _events = new ResponseEvent[dialogueObject.Responses.Length];
        } else {
            Array.Resize(ref _events, dialogueObject.Responses.Length);
        }

        for(int i = 0; i < dialogueObject.Responses.Length; i++) {
            Response response = dialogueObject.Responses[i];

            if(_events[i] != null) {
                _events[i].name = response.responseText;
                continue;
            }

            _events[i] = new ResponseEvent(){name = response.responseText};
        }
    }
}