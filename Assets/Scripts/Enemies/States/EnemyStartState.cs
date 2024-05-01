public class EnemyStartState : EnemyState
{
    private string _animationParam;
    public EnemyStartState(EnemyStateMachine machine, string animationParam) : base(machine)
    {
        _animationParam = animationParam;
    }

    public override void Enter()
    {
        Animator.OnAnimationCompleted += ChangeState;
        Animator.ChangeAnimationState(_animationParam, true);
    }

    private void ChangeState()
    {
        var nextState = EnemyBase.GetNextState();
        switch (nextState)
        {
            case EnemyStateType.Attack:
                Machine.ChangeState(EnemyBase.AttackState);
                break;
            case EnemyStateType.Idle:
                Machine.ChangeState(EnemyBase.IdleState);
                break;
            case EnemyStateType.Move:
                Machine.ChangeState(EnemyBase.MoveState);
                break;
        }
    }

    public override void Exit()
    {
        Animator.OnAnimationCompleted -= ChangeState;
        Animator.ChangeAnimationState(_animationParam, false);
    }
}
