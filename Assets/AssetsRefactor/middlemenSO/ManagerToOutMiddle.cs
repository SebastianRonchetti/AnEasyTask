using System;
using UnityEngine;

public class ManagerToOutMiddle : ScriptableObject {
    public static Action<float, float> _updateUIProgressBar;
}