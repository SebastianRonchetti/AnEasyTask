using UnityEngine;

public class CollectorTest : MonoBehaviour
{
    [SerializeField] private DialogueObjectSO _dialogueSOTest;
    public DialogueObjectSO DialogueSOTest => _dialogueSOTest;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T)){
            TestMiddleman.triggerFunctionTest?.Invoke();
        }
    }
}
