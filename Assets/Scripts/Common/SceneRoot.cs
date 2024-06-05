using UnityEngine;

public class SceneRoot : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Wave[] _waves;
    [SerializeField] private SceneTransitions _transitions;

    private int _currentWaveIndex;

    private void Awake()
    {
        _player.Init(_transitions);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Player player))
        {
            _collider.enabled = false;
            _waves[_currentWaveIndex].SpawnEnemies(SpawnNewWave);
            _currentWaveIndex++;
        }
    }

    private void SpawnNewWave() 
    {
        if (_currentWaveIndex >= _waves.Length)
        {
            _player.ShowUpgrade();
            return;
        }

        _waves[_currentWaveIndex].SpawnEnemies(SpawnNewWave);
        _currentWaveIndex++;
    }
}
