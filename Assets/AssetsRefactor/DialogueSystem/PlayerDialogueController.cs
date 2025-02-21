using UnityEngine;

public class PlayerDialogueController : MonoBehaviour {
    [SerializeField] private DialogueUI _dialogueUI;

    public DialogueUI dialogueUI => _dialogueUI;

    public IInteractable interactable {get; set;}

    private void Awake() {
        _dialogueUI = DialogueUI.Instance;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Q)){
            interactable?.interact(this);
        }
    }
}