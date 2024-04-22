using UnityEngine;

public class InAirState : PlayerState
{
    private Checker _checker;
    private bool _isGrounded;
    private Rigidbody2D _rigidBody2D;
    private AirStateData _data;
    private MoveStateData _moveData;
    private string _animationParameter;
    private bool _isJump;
    private Facing _facing;

    public InAirState(PlayerStateMachine stateMachine, AirStateData data, MoveStateData moveData, Facing facing, string animationParameter) : base(stateMachine)
    {
        _checker = Player.Checker;
        _rigidBody2D = Player.Rigidbody2D;
        _data = data;
        _animationParameter = animationParameter;
        _facing = facing;
        _moveData = moveData;
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

        if (Player.Combat.IsInHorizontalCombat)
        {
            return;
        }

        if (PlayerInputs.HorizontalMovementDirection != _facing.FacingDirection && PlayerInputs.HorizontalMovementDirection != 0)
        {
            _facing.Flip();
        }
    }

    public override void FixedUpdate()
    {
        float yVelocity = _rigidBody2D.velocity.y;
        float xVelocity = PlayerInputs.HorizontalMovementDirection * _moveData.MovementSpeed;

        if (_isJump)
        {
            yVelocity -= _data.JumpDownwardVelocity;
            xVelocity = PlayerInputs.HorizontalMovementDirection * _data.JumpHorizontalSpeed;
        }

        if (_rigidBody2D.velocity.y < 0)
        {
            _isJump = false;
            yVelocity -= _data.FallVelocity;
            if (yVelocity < _data.MaxFallVelocity * -1)
            {
                yVelocity = _data.MaxFallVelocity * -1;
            }
        }

        _rigidBody2D.velocity = new Vector2(xVelocity, yVelocity);
    }

    public void SetIsJumping() => _isJump = true;

    public override void Exit()
    {
        _isJump = false;
        PlayerAnimator.ChangeAnimationState(_animationParameter, false);

    }
}
