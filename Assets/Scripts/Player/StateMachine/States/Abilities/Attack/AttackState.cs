using UnityEngine;

public abstract class AttackState : State
{
    private string _animationParameter;
    private Checker _checker;
    private Rigidbody2D _rigidbody2D;
    protected Rigidbody2D Rigidbody2D => _rigidbody2D;
    public AttackState(PlayerStateMachine stateMachine, string animationParameter) : base(stateMachine)
    {
        _animationParameter = animationParameter;
        _rigidbody2D = Player.Rigidbody2D;
        _checker = Player.Checker;
    }

    protected virtual void FinishAtack() 
    {
        if (_checker.IsGrounded())
        {
            StateMachine.ChangeState(Player.IdleState);
            return;
        }

        StateMachine.ChangeState(Player.InAirState);
    }

    protected abstract void ChangeRigidbodyBehaviour();

    protected virtual void EnableHitbox() { }

    public override void Enter()
    {
        base.Enter();
        PlayerInputs.UseAttackInput();
        PlayerAnimator.OnAnimationCompleted += FinishAtack;
        PlayerAnimator.OnAnimationTriggered += EnableHitbox;
        PlayerAnimator.ChangeAnimationState(_animationParameter);
        ChangeRigidbodyBehaviour();
    }

    public override void Exit()
    {
        base.Exit();
        PlayerAnimator.OnAnimationCompleted -= FinishAtack;
        PlayerAnimator.OnAnimationTriggered -= EnableHitbox;
    }
}
