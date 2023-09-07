 using UnityEngine;

[CreateAssetMenu(fileName = "DialogueObjectSO", menuName = "AnEasyTaskv0.1/DialogueObjectSO", order = 0)]
public class DialogueObjectSO : ScriptableObject {
    [SerializeField] private string[] _dialogue; 
    [SerializeField] private string _choice1, _choice2;
    [SerializeField] readonly bool _choice;
    [SerializeField] private Response[] responses;
    public string[] Dialogue => _dialogue;
    public string Choice1 => _choice1;
    public string Choice2 => _choice2;
    public bool Choice => _choice;
    public bool HasResponses => Responses != null && Responses.Length > 0;
    public Response[] Responses => responses;
}