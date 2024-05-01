public class EnemyActionState : EnemyState
{
    private EnemyStateDataBase _data;
    public EnemyActionState(EnemyStateMachine machine, EnemyStateDataBase data) : base(machine)
    {
        _data = data;
        _data.SetReferences(EnemyBase.Rigidbody2D, EnemyBase.Animator, EnemyBase);
    }

    public override void Enter()
    {
        _data.EnterLogic();
    }

    public override void Exit()
    {
        _data.ExitLogic();
    }

    public override void FixedUpdate()
    {
        _data.FixedUpdateLogic();
    }

    public override void Update()
    {
        _data.UpdateLogic();
    }
}
