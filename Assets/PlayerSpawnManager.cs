using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputManager))]
public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField] Transform _playerOneSpawn;
    [SerializeField] Transform _playerTwoSpawn;
    // Start is called before the first frame update
    void OnPlayerJoined(PlayerInput playerInput)
    {
        playerInput.transform.position = playerInput.playerIndex == 1 ? _playerTwoSpawn.position : _playerOneSpawn.position;

    }
}
