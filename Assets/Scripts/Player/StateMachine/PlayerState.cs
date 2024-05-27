using UnityEngine;

public abstract class PlayerState : State
{
    private PlayerStateMachine _stateMachine;
    private Player _player;
    private Inputs _playerInputs;
    private CharacterAnimator _animator;
    protected PlayerStateMachine StateMachine => _stateMachine;
    protected Player Player => _player;
    protected Inputs PlayerInputs => _playerInputs;
    protected CharacterAnimator PlayerAnimator => _animator;
    public PlayerState(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        _player = _stateMachine.Player;
        _playerInputs = _player.Inputs;
        _animator = _player.Animator;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log(this);
    }

    public virtual void DoChecks() { }
}
