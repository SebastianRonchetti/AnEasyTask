using UnityEngine;
// In-world trigger for dialogue activation. Interactable dialogue object
public class DialogueActivator : MonoBehaviour, IInteractable {
    [SerializeField] public DialogueObjectSO dialogueObject;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && other.TryGetComponent(out PlayerDialogueController player)){
            player.interactable = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player") && other.TryGetComponent(out PlayerDialogueController player)){
            if(player.interactable is DialogueActivator dialogueActivator && dialogueActivator == this){
                player.interactable = null;
            }
        }
    }
    public void interact(PlayerDialogueController playerDialogueController) {
        if(TryGetComponent(out DialogueResponseEvent dialogueResponseEvent)) {
            Debug.Log($"Response events {dialogueResponseEvent}. Event smtsmt");
            playerDialogueController.dialogueUI.AddResponseEvents(dialogueResponseEvent.Events);
        }
        playerDialogueController.dialogueUI.ShowDialogue(dialogueObject);
    }
}