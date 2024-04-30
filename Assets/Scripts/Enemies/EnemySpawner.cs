using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPositions;
    [SerializeField] private EnemyPoolable[] _enemies;
    [SerializeField] private int _amountToSpawn;
    private ObjectPool<EnemyPoolable> _pool;

    private void Awake()
    {
        _pool = new(() => Instantiate(_enemies[UnityEngine.Random.Range(0, _enemies.Length)]),
                    (e) => e.gameObject.SetActive(true),
                    (e) => { },
                    (e) => Destroy(e.gameObject),
                    false);
    }

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        int amount = _amountToSpawn;
        
        if (amount > _spawnPositions.Length)
        {
            amount = _spawnPositions.Length;
        }

        for (int i = 0; i < amount; i++)
        {
            var enemy = _pool.Get();
            enemy.Init(KillAction, _spawnPositions[i].position);
        }
    }

    private void KillAction(EnemyPoolable enemy)
    {
        _pool.Release(enemy);
    }
}
