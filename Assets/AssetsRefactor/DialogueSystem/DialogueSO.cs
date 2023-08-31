using UnityEngine;

[CreateAssetMenu(fileName = "DialogueObjectSO", menuName = "AnEasyTaskv0.1/DialogueObjectSO", order = 0)]
public class DialogueSO : ScriptableObject {
    [SerializeField] [TextArea] private DialogueObjectSO[] _dialogue;

    public DialogueObjectSO[] Dialogue => _dialogue;
    public int _DialogueID;
}