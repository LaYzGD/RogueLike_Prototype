public abstract class State
{
    private PlayerStateMachine _stateMachine;
    private Player _player;
    protected PlayerStateMachine StateMachine => _stateMachine;
    protected Player Player => _player;
    public State(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        _player = _stateMachine.Player;
    }

    public virtual void Enter() { }
    public virtual void DoChecks() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void Exit() { }
}
