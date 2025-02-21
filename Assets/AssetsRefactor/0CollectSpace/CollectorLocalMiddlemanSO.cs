using UnityEngine;
using System;
public class CollectorLocalMiddlemanSO : ScriptableObject {
    public static Action OnGatherAllPickables;
    public static Action<Receptor> AddReceptorToManagerList;
    public static Action<PickableItem> AddItemToReceptorList;

    public static Action itemStored;
}