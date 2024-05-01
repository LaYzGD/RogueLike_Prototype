using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("States")]
    [SerializeField] private string _startAnimationParam;
    [Space]
    [SerializeField] private EnemyStateDataBase _idleData;
    [SerializeField] private EnemyStateDataBase _moveData;
    [SerializeField] private EnemyStateDataBase[] _attacksData;
    [SerializeField] private EnemyStateDataBase _deathData;
    [Header("Components")]
    [SerializeField] private EnemyStateType[] _states;
    [SerializeField] private CharacterAnimator _animator;
    [SerializeField] private Rigidbody2D _rigidBody2D;
    public CharacterAnimator Animator => _animator;
    public Rigidbody2D Rigidbody2D => _rigidBody2D;
    public EnemyStateType[] States => _states;

    public EnemyStateDataBase[] Attacks => _attacksData;

    private EnemyStateMachine _stateMachine;

    public EnemyStateMachine StateMachine => _stateMachine;
    public EnemyStartState StartState { get; private set; }
    public EnemyActionState IdleState { get; private set; }
    public EnemyActionState MoveState { get; private set; }
    public EnemyActionState AttackState { get; private set; }
    public EnemyDeathState DeathState { get; private set; }

    private int _index = 0;

    private void Awake()
    {
        _stateMachine = new EnemyStateMachine(this);

        var idleData = Instantiate(_idleData);
        var moveData = Instantiate(_moveData);
        var attackData = Instantiate(_attacksData[UnityEngine.Random.Range(0, _attacksData.Length)]);
        var deathData = Instantiate(_deathData);

        StartState = new EnemyStartState(_stateMachine, _startAnimationParam);
        IdleState = new EnemyActionState(_stateMachine, idleData);
        MoveState = new EnemyActionState(_stateMachine, moveData);
        AttackState = new EnemyActionState(_stateMachine, attackData);
        DeathState = new EnemyDeathState(_stateMachine, deathData);
    }

    private void OnEnable()
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
