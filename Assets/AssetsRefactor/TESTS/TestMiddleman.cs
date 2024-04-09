using System;
using UnityEngine;
public class TestMiddleman : ScriptableObject {
    public static Action<TimedEventSO> TriggerThis;
    public static Action<DialogueObjectSO> TriggerThis_dialogue;
    public static Action triggerFunctionTest;
    
}