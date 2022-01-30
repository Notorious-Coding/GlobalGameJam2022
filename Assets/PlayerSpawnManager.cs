using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputManager))]
public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField] Transform _playerOneSpawn;
    [SerializeField] Transform _playerTwoSpawn;

    [SerializeField] GameObject _firePlayer;
    [SerializeField] GameObject _waterPlayer;

    [SerializeField] PlayerInputManager _playerInputManager;
    [SerializeField] PlayerJoinGameEventSO _playerJoinGameEvent;
    // Start is called before the first frame update
    private void Start()
    {
        _playerInputManager.playerPrefab = _firePlayer;
    }
    void OnPlayerJoined(PlayerInput playerInput)
    {
        playerInput.transform.position = playerInput.playerIndex == 1 ? _playerTwoSpawn.position : _playerOneSpawn.position;
        _playerInputManager.playerPrefab = _waterPlayer;

        _playerJoinGameEvent.NotifyPlayerJoin(playerInput.playerIndex);
        if(_playerInputManager.playerCount == 2)
        {
            _playerJoinGameEvent.NotifyPlayersAreReady();
        }
    }
}
