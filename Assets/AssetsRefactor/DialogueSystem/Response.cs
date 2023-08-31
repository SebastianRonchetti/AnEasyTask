using UnityEngine;
[System.Serializable]
public class Response {
    [SerializeField] private string _responseText;
    [SerializeField] private DialogueObjectSO _pointer;
    public string responseText => _responseText;
    public DialogueObjectSO DObject => _pointer;

}