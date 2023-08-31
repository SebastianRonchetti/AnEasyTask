using UnityEngine;

public class PlayerDialogueController : MonoBehaviour {
    [SerializeField] private DialogueUI _dialogueUI;

    public DialogueUI dialogueUI => _dialogueUI;

    public IInteractable interactable {get; set;}

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)){
            
        }
    }
}