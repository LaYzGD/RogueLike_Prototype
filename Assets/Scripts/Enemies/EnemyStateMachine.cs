public class EnemyStateMachine : StateMachine
{
    private EnemyBase _enemyBase;
    public EnemyBase EnemyBase => _enemyBase;
    public EnemyStateMachine(EnemyBase enemyBase)
    {
        _enemyBase = enemyBase;
    }
}
