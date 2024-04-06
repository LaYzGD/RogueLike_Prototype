public abstract class State
{
    private PlayerStateMachine _stateMachine;
    private Player _player;
    private Inputs _playerInputs;
    private CharacterAnimator _animator;
    protected PlayerStateMachine StateMachine => _stateMachine;
    protected Player Player => _player;
    protected Inputs PlayerInputs => _playerInputs;
    protected CharacterAnimator PlayerAnimator => _animator;
    public State(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        _player = _stateMachine.Player;
        _playerInputs = _player.Inputs;
        _animator = _player.Animator;
    }

    public virtual void Enter() 
    {
        UnityEngine.Debug.Log(GetType());
    }
    public virtual void DoChecks() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void Exit() { }
}
