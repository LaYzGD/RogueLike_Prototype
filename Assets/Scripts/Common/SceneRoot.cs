using UnityEngine;

public class SceneRoot : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Wave[] _waves;

    private int _currentWaveIndex;

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
            print("Wave finished");
            return;
        }

        _waves[_currentWaveIndex].SpawnEnemies(SpawnNewWave);
        _currentWaveIndex++;
    }
}
