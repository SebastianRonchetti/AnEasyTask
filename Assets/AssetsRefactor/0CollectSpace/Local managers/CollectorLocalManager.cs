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
        ManagerToOutMiddle.backToWork += backToWork;
        ManagerToOutMiddle.unloadLevel += unload;
        ManagerMiddleman.onSceneLoaded?.Invoke();
    }

    private void OnDisable() {
        CollectorLocalMiddlemanSO.OnGatherAllPickables -= onChoreFulfilled;
        CollectorLocalMiddlemanSO.itemStored -= itemStored;
        ManagerToOutMiddle.backToWork -= backToWork;
        ManagerToOutMiddle.unloadLevel -= unload;
    }

    void unload(){
        ManagerMiddleman._loadWorkSceneAction?.Invoke();
    }

    private void Start() {
        dialogue = DialogueUI.Instance;
        dialogueResponseEvent = GetComponent<DialogueResponseEvent>();
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
        OnDisable();
        ManagerMiddleman.loadSceneByName("collectorScene");
    }

    public void backToWork(){
        OnDisable();
        ManagerMiddleman.loadSceneByName("workScene");
    }
}