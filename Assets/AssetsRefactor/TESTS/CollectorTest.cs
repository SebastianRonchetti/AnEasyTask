using UnityEngine;

public class CollectorTest : MonoBehaviour
{
    [SerializeField] private DialogueObjectSO _dialogueSOTest;
    public DialogueObjectSO DialogueSOTest => _dialogueSOTest;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J)){
            Debug.Log("ola");
            TestMiddleman.triggerFunctionTest?.Invoke();
        }
    }
}
