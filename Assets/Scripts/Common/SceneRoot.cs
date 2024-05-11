using UnityEngine;

public class SceneRoot : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private bool _hasTarget;
    [SerializeField] private EnemyBase[] _enemies;

    private void Awake()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Initialize(_hasTarget ? _player.transform : null);
        }
    }

    private void Start()
    {
        foreach(var enemy in _enemies) 
        {
            enemy.WakeUp();
        }
    }
}
