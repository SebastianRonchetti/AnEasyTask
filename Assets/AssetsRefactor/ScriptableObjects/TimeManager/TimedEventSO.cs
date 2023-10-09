using UnityEngine;


[CreateAssetMenu(fileName = "TimedEventSO", menuName = "AnEasyTaskv0.1/TimedEventSO", order = 0)]
public class TimedEventSO : ScriptableObject {
    [SerializeField] private float _timeMark;
    [SerializeField] private DialogueObjectSO _dialogueObject;
    public float TimeMark => _timeMark;
    public DialogueObjectSO Dialogue => _dialogueObject;

}