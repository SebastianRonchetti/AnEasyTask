using UnityEngine;
using System;
using System.Collections.Generic;

public class CollectorLocalManager : SingletonClass<CollectorLocalManager> {
    [SerializeField]List<Receptor> listOfReceptors;
    public event EventHandler<EventArgs> awaitInput;
    DialogueUI dialogue;
    [SerializeField]DialogueObjectSO levelEnd;
    DialogueResponseEvent dialogueResponseEvent;

    public void Awake() {
        _instantiate();
        dialogueResponseEvent = GetComponent<DialogueResponseEvent>();
        dialogue.CloseDialogueBox();
        CollectorLocalMiddlemanSO.OnGatherAllPickables += onChoreFulfilled;
        CollectorLocalMiddlemanSO.AddReceptorToManagerList += addToList;
    }

    private void Start() {
        dialogue = DialogueUI.Instance;
    }

    public void addToList(Receptor r){
        listOfReceptors.Add(r);
    }

    void onChoreFulfilled(){
        int totalReceptors = listOfReceptors.Count, completedReceptors = 0;
        foreach(Receptor r in listOfReceptors){
            if(r.complete){
                completedReceptors ++;
                if(completedReceptors >= totalReceptors){
                    dialogue.AddResponseEvents(dialogueResponseEvent.Events);
                    dialogue.ShowDialogue(levelEnd);
                }
            } else {
                break;
            }
        }
    }

    public void reload(){
        ManagerMiddleman.loadSceneByName("collectorScene");
    }

    public void backToWork(){
        ManagerMiddleman.loadSceneByName("workScene");
    }
}