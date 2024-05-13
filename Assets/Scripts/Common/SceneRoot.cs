using UnityEngine;

public class SceneRoot : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private EnemyBase[] _enemies;

    private void Awake()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Initialize( _player.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Player player))
        {
            _collider.enabled = false;
            foreach (var enemy in _enemies)
            {
                enemy.WakeUp();
            }
        }
    }
}
