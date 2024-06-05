using UnityEngine;

public class MoveState : GroundedState
{
    private PlayerData _data;
    private string _animationParameter;
    private Facing _facing;

    public MoveState(PlayerStateMachine stateMachine, PlayerData data, Facing facing, string animationParameter) : base(stateMachine)
    {
        _data = data;
        _facing = facing;
        _animationParameter = animationParameter;
    }

    public override void Enter()
    {
        base.Enter();
        PlayerAnimator.ChangeAnimationState(_animationParameter, true);
    }

    public override void Update()
    {
        base.Update();
        if (Rigidbody2D.velocity == Vector2.zero && PlayerInputs.HorizontalMovementDirection == 0)
        {
            StateMachine.ChangeState(Player.IdleState);
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
        base.FixedUpdate();
        Rigidbody2D.velocity = new Vector2(PlayerInputs.HorizontalMovementDirection * _data.MovementSpeed, Rigidbody2D.velocity.y);
    }

    public override void Exit()
    {
        base.Exit();
        PlayerAnimator.ChangeAnimationState(_animationParameter, false);
    }
}
