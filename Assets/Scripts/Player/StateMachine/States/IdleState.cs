using UnityEngine;

public class IdleState : GroundedState
{
    private string _animationParameter;

    public IdleState(PlayerStateMachine stateMachine, string animationParameter) : base(stateMachine)
    {
        _animationParameter = animationParameter;
    }

    public override void Enter()
    {
        base.Enter();
        Rigidbody2D.velocity = Vector2.zero;
        PlayerAnimator.ChangeAnimationState(_animationParameter, true);
    }

    public override void Update()
    {
        base.Update();
        if (PlayerInputs.HorizontalMovementDirection != 0)
        {
            StateMachine.ChangeState(Player.MoveState);
        }
    }

    public override void Exit()
    {
        PlayerAnimator.ChangeAnimationState(_animationParameter, false);
    }
}
