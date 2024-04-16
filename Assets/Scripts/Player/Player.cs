using UnityEngine;

public class Player : MonoBehaviour
{
    #region SerializeFields
    [Header("Components")]
    [SerializeField] private Inputs _inputs;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private CharacterAnimator _characterAnimator;
    [SerializeField] private Hook _hook;
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
    public HookLaunchState HookLaunchState { get; private set; }
    #region Attacks
    public AttackForwardState ForwardAttack { get; private set; }
    public AttackDownState DownAttack { get; private set; }
    public AttackNeutralState NeutralAttack { get; private set; }
    public AirAttackState AirAttack { get; private set; }
    #endregion
    #endregion

    #region Private Fields
    private Checker _checker;
    private PlayerStateMachine _stateMachine;
    #endregion

    #region Getters
    public Inputs Inputs => _inputs;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public Checker Checker => _checker;
    public CharacterAnimator Animator => _characterAnimator;
    public int FacingDirection => _facingDirection;
    #endregion

    private void Awake()
    {
        _checker = new Checker(_collider, _playerData.GroundCheckData, _rigidbody2D);
        _stateMachine = new PlayerStateMachine(this);

        InAirState = new InAirState(_stateMachine,
                                    _playerData.AirStateData,
                                    _playerData.MoveStateData,
                                    _playerData.CharacterAnimationsData.InAirAnimationParameter);
        IdleState = new IdleState(_stateMachine,
                                  _playerData.CharacterAnimationsData.IdleAnimationParameter);
        MoveState = new MoveState(_stateMachine,
                                  _playerData.MoveStateData,
                                  _playerData.CharacterAnimationsData.MoveAnimationParameter);
        LandState = new LandState(_stateMachine);
        JumpState = new JumpState(_stateMachine, _playerData.JumpStateData);
        HookLaunchState = new HookLaunchState(_stateMachine, _hook);
        ForwardAttack = new AttackForwardState(_stateMachine, _playerData.AttackForwardData, _playerData.CharacterAnimationsData.AttackForward);
        DownAttack = new AttackDownState(_stateMachine, _playerData.AttacDownData, _playerData.CharacterAnimationsData.AttackDown);
        NeutralAttack = new AttackNeutralState(_stateMachine, _playerData.CharacterAnimationsData.AttackNeutral);
        AirAttack = new AirAttackState(_stateMachine, _playerData.CharacterAnimationsData.AirAttack);
    }

    private void OnEnable()
    {
        _stateMachine.Start(IdleState);
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    private void FixedUpdate()
    {
        _stateMachine.FixedUpdate();
    }

    public void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
        _facingDirection *= -1;
    }
}
