using UnityEngine;

public abstract class GroundedState : PlayerState
{
    private Checker _checker;
    private bool _isGrounded;
    private Rigidbody2D _rigidbody2D;

    protected Rigidbody2D Rigidbody2D => _rigidbody2D;

    public GroundedState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        _checker = Player.Checker;
        _rigidbody2D = Player.Rigidbody2D;
    }

    public override void DoChecks()
    {
        _isGrounded = _checker.IsGrounded();

    }

    public override void Enter()
    {
        base.Enter();
        DoChecks();
    }

    public override void Update() 
    {
        DoChecks();

        if (PlayerInputs.IsJump)
        {
            PlayerInputs.UseJumpInput();
            StateMachine.ChangeState(Player.JumpState);
        }


        if (!_isGrounded)
        {
            StateMachine.ChangeState(Player.InAirState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
