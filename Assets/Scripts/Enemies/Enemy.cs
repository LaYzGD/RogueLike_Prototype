using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [Header("Components")]
    [SerializeField] private CharacterAnimator _animator;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [Header("Checks")]
    [SerializeField] private Transform _targetCheckOrigin;
    [SerializeField] private Transform _frontCheckOrigin;
    [SerializeField] private Transform _downCheckOrigin;
    [Header("Data")]
    [SerializeField] private EnemyData _enemyData;
    [Header("Values")]
    [SerializeField] private int _defaultFacingDirection;
    [SerializeField] private float _frontDistance;
    [SerializeField] private float _downDistance;

    private Facing _facing;
    private WayDetection _wayDetection;
    private TargetDetection<Player> _targetDetection;
    private EnemyStateMachine _enemyStateMachine;
    public EnemyMoveState MoveState { get; private set; }
    public EnemyChaseState ChaseState { get; private set; }
    public EnemyAttackState AttackState { get; private set; }
    public Facing Facing => _facing;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public CharacterAnimator Animator => _animator;
    public TargetDetection<Player> TargetDetection => _targetDetection;

    private void Awake()
    {
        _facing = new Facing(transform, _defaultFacingDirection);
        _wayDetection = new WayDetection(_frontDistance, _downDistance, _frontCheckOrigin, _downCheckOrigin, _enemyData.GroundLayer, _facing);
        _targetDetection = new TargetDetection<Player>(_targetCheckOrigin, _enemyData.TargetLayer);
        _enemyStateMachine = new EnemyStateMachine(this);
        MoveState = new EnemyMoveState(_enemyStateMachine, _wayDetection, _enemyData.MovementSpeed, _enemyData.DetectionRange, _enemyData.MoveAnimation);
        ChaseState = new EnemyChaseState(_enemyStateMachine, _wayDetection, _enemyData.DetectionRange, _enemyData.AttackRange, _enemyData.ChaseSpeed, _enemyData.ChaseAnimation);
        AttackState = new EnemyAttackState(_enemyStateMachine, _enemyData.AttackAnimation);
    }

    private void Start()
    {
        _enemyStateMachine.Start(MoveState);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(damage);
    }

    private void Update()
    {
        _enemyStateMachine.Update();
    }

    private void FixedUpdate()
    {
        _enemyStateMachine.FixedUpdate();
    }
}
