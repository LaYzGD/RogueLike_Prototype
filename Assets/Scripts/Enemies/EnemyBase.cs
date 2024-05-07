using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("States")]
    [SerializeField] private string _startAnimationParam;
    [Space]
    [SerializeField] private EnemyStateDataBase _idleData;
    [SerializeField] private EnemyStateDataBase _moveData;
    [SerializeField] private Stage _stage;
    [SerializeField] private EnemyStateDataBase _deathData;
    [Header("Components")]
    [SerializeField] private EnemyStateType[] _states;
    [SerializeField] private CharacterAnimator _animator;
    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private Transform _body;
    [SerializeField] private Health _health;
    [Header("Data")]
    [SerializeField] private int _maxHealth;
    [SerializeField] private int[] _healthToChangeStage;
    [SerializeField] private int _defaultFacingDirection;
    [SerializeField] private float _checkCloseThreshold;
    [SerializeField] private float _checkFarThreshold;
    [Space]
    [SerializeField] private float _checkDistance;
    [SerializeField] private LayerMask _targetLayerMask;

    private int _index = 0;
    private int _stageIndex = 0;
    private EnemyAttacks _currentStage;
    private EnemyStateMachine _stateMachine;
    private Facing _facing;
    private Transform _target;
    private TargetDetection _targetDetection;

    public CharacterAnimator Animator => _animator;
    public Rigidbody2D Rigidbody2D => _rigidBody2D;
    public EnemyStateType[] States => _states;
    public Facing Facing => _facing;
    public Transform Target => _target;
    public Transform Body => _body;
    public float CloseThreshold => _checkCloseThreshold;
    public float FarThreshold => _checkFarThreshold;
    public TargetDetection TargetDetection => _targetDetection;

    public EnemyAttacks Attacks => _stage.Stages[_stageIndex];
    public EnemyStateMachine StateMachine => _stateMachine;
    public EnemyStartState StartState { get; private set; }
    public EnemyActionState IdleState { get; private set; }
    public EnemyActionState MoveState { get; private set; }
    public EnemyActionState AttackState { get; private set; }
    public EnemyDeathState DeathState { get; private set; }

    public void Initialize(Transform target = null)
    {
        if (target != null)
        {
            _target = target;
        }

        _stateMachine = new EnemyStateMachine(this);
        _facing = new Facing(_body, _defaultFacingDirection);
        _currentStage = Instantiate(_stage.Stages[_stageIndex]);
        _targetDetection = new TargetDetection(_checkDistance, _rigidBody2D.transform, _facing, _targetLayerMask);

        var idleData = Instantiate(_idleData);
        var moveData = Instantiate(_moveData);
        var attackData = Instantiate(_currentStage.DefaultAttacks[UnityEngine.Random.Range(0, _currentStage.DefaultAttacks.Count)]);
        var deathData = Instantiate(_deathData);

        StartState = new EnemyStartState(_stateMachine, _startAnimationParam);
        IdleState = new EnemyActionState(_stateMachine, idleData);
        MoveState = new EnemyActionState(_stateMachine, moveData);
        AttackState = new EnemyActionState(_stateMachine, attackData);
        DeathState = new EnemyDeathState(_stateMachine, deathData);
        _health.Init(_maxHealth);
        _health.OnDamaged += CheckStageTransition;
    }

    public void WakeUp()
    {
        _stateMachine.Start(StartState);
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    private void FixedUpdate()
    {
        _stateMachine.FixedUpdate();
    }

    public void SetNewAttackData(EnemyStateDataBase data)
    {
        var newAttackData = Instantiate(data);
        AttackState = new EnemyActionState(_stateMachine, newAttackData);
    }

    private void CheckStageTransition(int currentHealth)
    {
        if (_stageIndex >= _healthToChangeStage.Length)
        {
            return;
        }

        if (currentHealth <= _healthToChangeStage[_stageIndex])
        {
            GoToNextStage();
        }
    }

    public virtual void GoToNextStage()
    {
        if (_stageIndex >= _stage.Stages.Length)
        {
            return;
        }

        _stageIndex++;
        _currentStage = Instantiate(_stage.Stages[_stageIndex]);
        if (_currentStage.Controller != null)
        {
            _animator.SetController(_currentStage.Controller);
        }
    }

    public EnemyStateType GetNextState()
    {
        var index = _index;
        _index++;

        if (_index >= _states.Length)
        {
            _index = 0;
        }

        return _states[index];
    }
}
