using UnityEngine;

public class LandState : GroundedState
{
    private string _animationParameter;
    public LandState(PlayerStateMachine stateMachine, string animationParameter) : base(stateMachine)
    {
        _animationParameter = animationParameter;
    }

    public override void Enter()
    {
        base.Enter();
        PlayerAnimator.OnAnimationCompleted += ChangeState;
        PlayerAnimator.ChangeAnimationState(_animationParameter);
    }

    private void ChangeState()
    {
        if (PlayerInputs.HorizontalMovementDirection != 0)
        {
            StateMachine.ChangeState(Player.MoveState);
            return;
        }

        StateMachine.ChangeState(Player.IdleState);
    }
}
