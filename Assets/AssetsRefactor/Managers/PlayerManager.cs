using UnityEngine;
class PlayerManager : SingletonClass<PlayerManager> {
    GameObject _player;
    public GameObject Player => _player;

    private void Awake() {
        ManagerToOutMiddle.setPlayerOnScene += OnSceneLoad;
        //PlayerStateMachine.AddState();
    }

    void OnSceneLoad(GameObject playerOnScene){
        _player = ManagerToOutMiddle.PlayerOnScene;
    }
}