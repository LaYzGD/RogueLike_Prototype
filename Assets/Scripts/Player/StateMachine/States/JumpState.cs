using UnityEngine;

public class JumpState : AbilityState
{
    private JumpStateData _data;
    private string _jumpAnimationParameter;
    public JumpState(PlayerStateMachine stateMachine,
                     bool isUnlockedByDefault,
                     JumpStateData data,
                     string jumpAnimationParameter) : base(stateMachine, isUnlockedByDefault)
    {
        _data = data;
        _jumpAnimationParameter = jumpAnimationParameter;
    }

    private void Jump()
    {
        Vector2 jumpVector = new Vector2(Rigidbody.velocity.x,
                                         _data.JumpVerticalForce);
        Rigidbody.velocity = jumpVector;
    }

    private void FinishAbility() => IsAbilityDone = true;

    public override void Enter()
    {
        base.Enter();
        PlayerAnimator.OnAnimationTriggered += Jump;
        PlayerAnimator.OnAnimationCompleted += FinishAbility;
        PlayerAnimator.ChangeAnimationState(_jumpAnimationParameter);
    }

    public override void Update()
    {
        base.Update();
        if (IsAbilityDone) 
        {
            StateMachine.ChangeState(Player.InAirState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        PlayerAnimator.OnAnimationTriggered -= Jump;
        PlayerAnimator.OnAnimationCompleted -= FinishAbility;
    }
}
