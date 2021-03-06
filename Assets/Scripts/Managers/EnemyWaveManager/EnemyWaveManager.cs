using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    [SerializeField] List<EnemyWave> _firstWave;
    [SerializeField] WavesGameEvents _wavesEventsHandler;
    [SerializeField] WavesGameEventData _wavesGameEventData;
    [SerializeField] Transform _enemiesHolder;
    [SerializeField] Transform _spawnerPointsHolder;
    [SerializeField] Chaman _chaman;
    List<Enemy> _currentWave = new List<Enemy>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_wavesGameEventData.WaveRate.isEnded)
        {
            _wavesGameEventData.WaveRate.Stop();
            _wavesGameEventData.WaveRate.Start();
            _wavesEventsHandler.FireStartNextWave(_wavesGameEventData);
            Spawn();
            _wavesGameEventData.CurrentWaveCounter += 1;
        }
    }

    private void Spawn()
    {
        foreach (var enemy in _firstWave)
        {
            var enemyCount = ComputeCurrentWaveEnemyCount(enemy.Count);
            Debug.Log(enemyCount);

            for(int i = 0; i < enemyCount; i++)
            {
                var spawnPoint = GetRandomSpawnPoint();
                var instantiated = Instantiate(enemy.EnemyPrefab, spawnPoint.position, Quaternion.identity, _enemiesHolder);
                instantiated.LockTarget(_chaman);
                _currentWave.Add(instantiated);
            }
        }
    }

    private float ComputeCurrentWaveEnemyCount(int enemyNumber)
    {
        float value = enemyNumber;
        for(int i = 0; i < _wavesGameEventData.CurrentWaveCounter; i++)
        {
            value = Mathf.Pow(enemyNumber, _wavesGameEventData.EnemyCountMultiplicator);
        }
        
        return value;
    }

    private Transform GetRandomSpawnPoint()
    {
        var index = Random.Range(0, _spawnerPointsHolder.transform.childCount);
        return _spawnerPointsHolder.GetChild(index);
    }
}
