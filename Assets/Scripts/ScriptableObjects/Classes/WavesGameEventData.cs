[System.Serializable]
public class WavesGameEventData
{
    /// <summary>
    /// Numero de la vague d'ennemi courante.
    /// </summary>
    public int CurrentWaveCounter = 1;

    /// <summary>
    /// Temps de spawn entre deux vague d'ennemies.
    /// </summary>
    public Cooldown WaveRate;

    /// <summary>
    /// Multiplicateur du nombre d'ennemies.
    /// </summary>
    public float EnemyCountMultiplicator;
}

