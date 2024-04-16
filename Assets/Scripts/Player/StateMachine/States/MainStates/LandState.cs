using UnityEngine;

public class LandState : GroundedState
{
    public LandState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        ChangeState();
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
