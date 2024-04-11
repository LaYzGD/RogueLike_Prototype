using UnityEngine;

public class InAirState : State
{
    private Checker _checker;
    private bool _isGrounded;
    private Rigidbody2D _rigidBody2D;
    private AirStateData _data;
    private MoveStateData _moveData;
    private string _animationParameter;
    private string _fallAnimationParameter;
    private bool _isJump;
    private bool _isFallingStarted;

    public InAirState(PlayerStateMachine stateMachine, AirStateData data, MoveStateData moveData, string animationParameter, string fallAnimation) : base(stateMachine)
    {
        _checker = Player.Checker;
        _rigidBody2D = Player.Rigidbody2D;
        _data = data;
        _animationParameter = animationParameter;
        _fallAnimationParameter = fallAnimation;
        _moveData = moveData;
    }

    public override void Enter()
    {
        base.Enter();
        _isFallingStarted = false;
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

        if (_rigidBody2D.velocity.y < -_data.FallVelocityTreshold)
        {
            _isFallingStarted = true;
        }

        if (_isFallingStarted)
        {
            PlayerAnimator.ChangeAnimationState(_animationParameter, false);
            PlayerAnimator.ChangeAnimationState(_fallAnimationParameter, true);
        }

        if (PlayerInputs.HorizontalMovementDirection != Player.FacingDirection && PlayerInputs.HorizontalMovementDirection != 0)
        {
            Player.Flip();
        }

        if (!_isGrounded)
        {
            return;
        }

        if (PlayerInputs.HorizontalMovementDirection != 0)
        {
            StateMachine.ChangeState(Player.MoveState);
            return;
        }


        StateMachine.ChangeState(Player.LandState);
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
        _isFallingStarted = false;
        PlayerAnimator.ChangeAnimationState(_animationParameter, false);
        PlayerAnimator.ChangeAnimationState(_fallAnimationParameter, false);
    }
}
