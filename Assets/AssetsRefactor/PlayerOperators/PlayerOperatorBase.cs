using UnityEngine;
[System.Serializable]
public abstract class PlayerOperatorBase : ScriptableObject {
    [SerializeField] string _sceneCode; 
    public string SceneID => _sceneCode;
    public abstract void OnEnterState(PlayerStateMachine playerStateMachine);
    public abstract void UpdateState(PlayerStateMachine stateMachine);
    public abstract void computeInput(float _horizontal, float _vertical);
    public abstract void computeInput(KeyCode keyCode);
    public abstract void OnExitState();
}