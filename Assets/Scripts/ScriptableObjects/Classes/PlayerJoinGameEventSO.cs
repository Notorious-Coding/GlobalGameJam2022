using UnityEditor;
using UnityEngine;


public delegate void OnPlayersAreReadyDelegate();
public delegate void PlayerJoinDelegate();

[CreateAssetMenu(menuName = "PlayerJoinGameEvent")]
public class PlayerJoinGameEventSO : ScriptableObject
{
    private event OnPlayersAreReadyDelegate OnPlayersAreReadyEvent;


    public void Subscribe(OnPlayersAreReadyDelegate @delegate)
    {
        OnPlayersAreReadyEvent += @delegate;
    }

    public void Unsubscribe(OnPlayersAreReadyDelegate @delegate)
    {
        OnPlayersAreReadyEvent -= @delegate;
    }

    public void NotifyPlayersAreReady()
    {
        OnPlayersAreReadyEvent?.Invoke();
    }
}