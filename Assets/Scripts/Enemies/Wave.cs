using System;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemyBase[] _enemies;

    private int _enemiesCount;
    private Action _onWaveFinished;

    private void Awake()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Initialize(this, _player.transform);
        }
    }

    public void SpawnEnemies(Action onWaveFinished)
    {
        _enemiesCount = _enemies.Length;
        _onWaveFinished = onWaveFinished;
        foreach (var enemy in _enemies)
        {
            enemy.WakeUp();
        }
    }

    public void CheckEnemies()
    {
        _enemiesCount--;
        if (_enemiesCount <= 0)
        {
            _onWaveFinished();
        }
    }
}
