using UnityEngine;

public class JumpState : AbilityState
{
    private JumpStateData _data;
    public JumpState(PlayerStateMachine stateMachine, JumpStateData data) : base(stateMachine)
    {
        _data = data;
    }

    public override void Enter()
    {
        base.Enter();
        Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, _data.JumpForce);
        PlayerInputs.UseJumpInput();
        Player.InAirState.SetIsJumping();
        IsAbilityDone = true;
    }
}
