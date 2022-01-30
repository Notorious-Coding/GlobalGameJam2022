using UnityEditor;
using UnityEngine;


public delegate void OnPlayersAreReadyDelegate();
public delegate void OnPlayerJoinDelegate(int playerNumber);

[CreateAssetMenu(menuName = "PlayerJoinGameEvent")]
public class PlayerJoinGameEventSO : ScriptableObject
{
    private event OnPlayersAreReadyDelegate OnPlayersAreReadyEvent;
    private event OnPlayerJoinDelegate OnPlayerJoinEvent;


    public void Subscribe(OnPlayersAreReadyDelegate @delegate)
    {
        OnPlayersAreReadyEvent += @delegate;
    }

    public void Unsubscribe(OnPlayersAreReadyDelegate @delegate)
    {
        OnPlayersAreReadyEvent -= @delegate;
    }

    public void Subscribe(OnPlayerJoinDelegate @delegate)
    {
        OnPlayerJoinEvent += @delegate;
    }

    public void Unsubscribe(OnPlayerJoinDelegate @delegate)
    {
        OnPlayerJoinEvent -= @delegate;
    }

    public void NotifyPlayersAreReady()
    {
        OnPlayersAreReadyEvent?.Invoke();
    }

    public void NotifyPlayerJoin(int playerNumber)
    {
        OnPlayerJoinEvent?.Invoke(playerNumber);
    }
}