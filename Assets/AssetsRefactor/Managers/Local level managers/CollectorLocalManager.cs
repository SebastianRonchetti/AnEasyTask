using UnityEngine;
using System;

public class CollectorLocalManager : SingletonClass<CollectorLocalManager> {
    
    int amountOfPickablesInLevel;
    DialogueUI dialogue;
    [SerializeField] string _pickableTag;
    [SerializeField] DialogueObjectSO levelEnd;
    [SerializeField] DialogueResponseEvent dialogueResponseEvent;

    public void Awake() {
        _instantiate();
        CollectorLocalMiddlemanSO.OnGatherAllPickables += onChoreFulfilled;
        CollectorLocalMiddlemanSO.itemStored += itemStored;
        TestMiddleman.triggerFunctionTest += onChoreFulfilled;
    }

    private void Start() {
        dialogue = DialogueUI.Instance;
        dialogueResponseEvent = GetComponent<DialogueResponseEvent>();
        dialogue.CloseDialogueBox();
        setAmountOfPickables();
    }
    

    void setAmountOfPickables(){
        GameObject[] Pickables = GameObject.FindGameObjectsWithTag(_pickableTag);
        amountOfPickablesInLevel = Pickables.Length;
        Pickables = null;
    }

    void itemStored(){
        amountOfPickablesInLevel --;
        if(amountOfPickablesInLevel <= 0){
            onChoreFulfilled();
        }
    }

    void onChoreFulfilled(){
        dialogue.ShowDialogue(levelEnd);
        //dialogue.AddResponseEvents(dialogueResponseEvent.Events);
    }

    public void reload(){
        ManagerMiddleman.loadSceneByName("collectorScene");
    }

    public void backToWork(){
        ManagerMiddleman.loadSceneByName("workScene");
    }
}