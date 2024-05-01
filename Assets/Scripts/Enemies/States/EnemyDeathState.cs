public class EnemyDeathState : EnemyState
{
    private EnemyStateDataBase _data;
    private string _animationParam;
    public EnemyDeathState(EnemyStateMachine machine, EnemyStateDataBase data) : base(machine)
    {
        _data = data;
        _animationParam = _data.AnimationParamName;
        _data.SetReferences(EnemyBase.Rigidbody2D, EnemyBase.Animator, EnemyBase);
    }
    public override void Enter()
    {
        Animator.OnAnimationCompleted += DoDeathLogic;
        Animator.ChangeAnimationState(_animationParam, true);
    }

    private void DoDeathLogic()
    {
        _data.AnimationCompletedLogic();
    }

    public override void Exit()
    {
        Animator.OnAnimationCompleted -= DoDeathLogic;
        Animator.ChangeAnimationState(_animationParam, false);
    }
}
