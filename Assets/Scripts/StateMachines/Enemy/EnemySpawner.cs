using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour,ITargetLock
{
    [SerializeField] private Enemy _enemy;

    [SerializeField] private Cooldown _cooldown;

    private Entity _chaman;

    private bool _enemyIsInstantiated;
    // Start is called before the first frame update
    void Start()
    {
        _cooldown.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (_cooldown.isEnded && !_enemyIsInstantiated)
        {
            Enemy enemy = Instantiate(_enemy, transform.position, Quaternion.identity);
            enemy.LockTarget(_chaman);
            Destroy(gameObject);
            _enemyIsInstantiated = true;
        }
    }

    public void LockTarget(Entity chaman)
    {
        _chaman = chaman;
    }
}
