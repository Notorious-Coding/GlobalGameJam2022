using UnityEngine;

public delegate void OnNewWaveStartDelegate(WavesGameEventData eventData);
[CreateAssetMenu(menuName = "WavesData")]
public class WavesGameEvents : ScriptableObject
{
    public event OnNewWaveStartDelegate OnNewWaveStartGameEvent;

    public void FireStartNextWave(WavesGameEventData eventData)
    {
        OnNewWaveStartGameEvent?.Invoke(eventData);
    }

    public void Subscribe(OnNewWaveStartDelegate newWaveStartDelegate)
    {
        OnNewWaveStartGameEvent += newWaveStartDelegate;
    }

    public void Unsubscribe(OnNewWaveStartDelegate newWaveStartDelegate)
    {
        OnNewWaveStartGameEvent -= newWaveStartDelegate;
    }
}

