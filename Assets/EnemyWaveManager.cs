using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    [SerializeField] List<Enemy> _enemies;
    [SerializedField] WavesDataSO _wavesData;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_wavesData.WaveRate.isEnded)
        {
            _waveRate.Stop();
            _waveRate.Start();
            _waveNumber += 1;
            Spawn();
        }
    }

    private void Spawn()
    {
        
    }
}
