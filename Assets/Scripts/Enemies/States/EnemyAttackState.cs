using UnityEngine;

public class EnemyAttackState : EnemyState
{
    private string _animationParam;
    public EnemyAttackState(EnemyStateMachine stateMachine, string animationParam) : base(stateMachine)
    {
        _animationParam = animationParam;
    }

    public override void Enter()
    {
        base.Enter();
        Rigidbody2D.velocity = Vector2.zero;
        Enemy.Animator.OnAnimationCompleted += ChangeState;
        Enemy.Animator.ChangeAnimationState(_animationParam, true);
    }

    private void ChangeState()
    {
        StateMachine.ChangeState(Enemy.MoveState);
    }

    public override void Exit()
    {
        base.Exit();
        Enemy.Animator.OnAnimationCompleted -= ChangeState;
        Enemy.Animator.ChangeAnimationState(_animationParam, false);
    }
}
