using UnityEngine;

public abstract class PlayerOperatorBase : MonoBehaviour {
    PlayerManager playerManager;
    public abstract void OnEnterState(PlayerStateMachine playerStateMachine);
    public abstract void UpdateState();
    public abstract void computeInput(KeyCode _keyCode, float _intensity);
    public abstract void OnExitState();
}