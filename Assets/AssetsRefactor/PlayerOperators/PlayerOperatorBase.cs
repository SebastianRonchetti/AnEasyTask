using UnityEngine;

public abstract class PlayerOperatorBase : MonoBehaviour {
    PlayerManager playerManager;
    public abstract void OnEnterState(PlayerStateMachine playerStateMachine);
    public abstract void UpdateState();
    public abstract void computeInput(float _horizontal, float _vertical);
    public abstract void OnExitState();

    public abstract void getPlayer();
}