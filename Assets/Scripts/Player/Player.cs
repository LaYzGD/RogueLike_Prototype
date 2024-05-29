using UnityEngine;

public class Player : MonoBehaviour
{
    #region SerializeFields
    [Header("Components")]
    [SerializeField] private Inputs _inputs;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private CharacterAnimator _characterAnimator;
    [SerializeField] private Combat _combat;
    [SerializeField] private Health _health;
    [SerializeField] private ParticleSystem _hitParticles;
    [Header("Data")]
    [SerializeField] private PlayerData _playerData;
    [Header("Variables")]
    [SerializeField] private int _facingDirection = 1;
    #endregion

    #region States
    public InAirState InAirState { get; private set; }
    public IdleState IdleState { get; private set; }
    public MoveState MoveState { get; private set; }
    public LandState LandState { get; private set; }
    public JumpState JumpState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    #endregion

    #region Private Fields
    private Checker _checker;
    private Facing _facing;
    private PlayerStateMachine _stateMachine;
    #endregion

    #region Getters
    public Inputs Inputs => _inputs;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public Checker Checker => _checker;
    public CharacterAnimator Animator => _characterAnimator;
    public Combat Combat => _combat;
    public Facing Facing => _facing;
    #endregion

    private void Awake()
    {
        _checker = new Checker(_collider, _playerData.GroundCheckData, _rigidbody2D);
        _facing = new Facing(transform, _facingDirection);
        _stateMachine = new PlayerStateMachine(this);

        InAirState = new InAirState(_stateMachine,
                                    _playerData.AirStateData,
                                    _playerData.MoveStateData,
                                    _facing,
                                    _playerData.CharacterAnimationsData.InAirAnimationParameter);
        IdleState = new IdleState(_stateMachine,
                                  _playerData.CharacterAnimationsData.IdleAnimationParameter);
        MoveState = new MoveState(_stateMachine,
                                  _playerData.MoveStateData,
                                  _facing,
                                  _playerData.CharacterAnimationsData.MoveAnimationParameter);
        LandState = new LandState(_stateMachine);
        JumpState = new JumpState(_stateMachine, _playerData.JumpStateData);
        DashState = new PlayerDashState(_stateMachine, _playerData.DashStateData);
        _combat.Initialize(_facing);
        _health.Init(_playerData.MaxHealth, false);
    }

    private void OnEnable()
    {
        _stateMachine.Start(IdleState);
        _health.OnDamaged += Damaged;
        _health.OnDie += Die;
    }

    private void Damaged(int health, Vector2 direction)
    {
        _hitParticles.Play();
    }

    private void Die()
    {
        print("Dead");
    }

    private void Update()
    {
        _stateMachine.Update();
        _combat.UpdateCombat();
    }

    private void FixedUpdate()
    {
        _stateMachine.FixedUpdate();
    }
}
