using UnityEngine;

// Info holder for time marks and pointers towards related dialogue
[CreateAssetMenu(fileName = "TimedEventSO", menuName = "AnEasyTaskv0.1/TimedEventSO", order = 0)]
public class TimedEventSO : ScriptableObject {
    [SerializeField] private timedEventVariables[] _timeMark;
    [SerializeField] private DialogueObjectSO _dialogueObject;
    [SerializeField] private ArticleSO _articleObject;
    public timedEventVariables[] TimeMark => _timeMark;
    public DialogueObjectSO Dialogue => _dialogueObject;
    public ArticleSO ArticleObject => _articleObject;

}

[System.Serializable]
public class timedEventVariables {
    [SerializeField] private float _timeMark;
    [SerializeField] private bool _triggered;
    public float TimeMark => _timeMark;
    public bool Triggered => _triggered;

    public void trigger(){
        if(!_triggered){
            _triggered = true;
        }
    }

    public void disableTrigger(){
        if(_triggered){
            _triggered = false;
        }
    }
}