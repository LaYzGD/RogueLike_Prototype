using UnityEngine;

public class SceneRoot : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemyBase _boss;

    private void Awake()
    {
        _boss.Initialize(_player.transform);    
    }

    private void Start()
    {
        _boss.WakeUp();
    }
}
