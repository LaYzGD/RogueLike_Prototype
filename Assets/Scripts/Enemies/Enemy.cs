using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private CharacterAnimator _animator;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform _targetCheckOrigin;
    [SerializeField] private GroundCheckData _checkData;
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private int _defaultFacingDirection = 1;

    private Checker _checker;
    private Facing _facing;
    private TargetDetection<Player> _targetDetection;
    public Checker Checker => _checker;
    public Facing Facing => _facing;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public CharacterAnimator Animator => _animator;
    public TargetDetection<Player> TargetDetection => _targetDetection;

    private void Awake()
    {
        _checker = new Checker(_collider, _checkData, _rigidbody2D);
        _facing = new Facing(transform, _defaultFacingDirection);
        _targetDetection = new TargetDetection<Player>(_targetCheckOrigin, _targetLayer);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(damage);
    }
}
