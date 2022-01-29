using UnityEngine;

public delegate void OnNewWaveStartDelegate();
[CreateAssetMenu(menuName = "WavesData")]
public class WavesDataSO
{
    public int WaveNumber;
    public Cooldown WaveRate;
    public int FirstWaveEnemyCount;
    public float Multiplicator;

    public event OnNewWaveStartDelegate OnNewWaveStartEvent;

    public void StartNextWave(int value)
    {
        Life += value;
        OnLifeChangeEvent(Life);
    }

    public void Subscribe(OnLifeChangeDelegate takeDamageDelegate)
    {
        OnLifeChangeEvent += takeDamageDelegate;
    }

    public void Unsubscribe(OnLifeChangeDelegate takeDamageDelegate)
    {
        OnLifeChangeEvent -= takeDamageDelegate;
    }
}

