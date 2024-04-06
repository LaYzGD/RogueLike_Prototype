using UnityEngine;

public class InAirState : State
{
    private Checker _checker;
    private bool _isGrounded;
    private Rigidbody2D _rigidBody2D;
    private AirStateData _data;
    private string _animationParameter;

    public InAirState(PlayerStateMachine stateMachine, AirStateData data, string animationParameter) : base(stateMachine)
    {
        _checker = Player.Checker;
        _rigidBody2D = Player.Rigidbody2D;
        _data = data;
        _animationParameter = animationParameter;
    }

    public override void Enter()
    {
        base.Enter();
        DoChecks();
        PlayerAnimator.ChangeAnimationState(_animationParameter, true);
    }

    public override void DoChecks()
    {
        _isGrounded = _checker.IsGrounded();
    }

    public override void Update()
    {
        DoChecks();

        if (_isGrounded)
        {
            StateMachine.ChangeState(Player.LandState);
        }
    }

    public override void FixedUpdate()
    {
        float yVelocity = _rigidBody2D.velocity.y;
        float xVelocity = PlayerInputs.HorizontalMovementDirection * _data.HorizontalSpeed;

        if (_rigidBody2D.velocity.y < 0)
        {
            yVelocity -= _data.FallVelocity;   
        }

        _rigidBody2D.velocity = new Vector2(xVelocity, yVelocity);
    }

    public override void Exit()
    {
        PlayerAnimator.ChangeAnimationState(_animationParameter, false);
    }
}
