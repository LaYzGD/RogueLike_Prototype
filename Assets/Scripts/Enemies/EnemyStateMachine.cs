public class EnemyStateMachine : StateMachine
{
    private Enemy _enemy;
    public Enemy Enemy => _enemy; 
    public EnemyStateMachine(Enemy enemy) 
    {
        _enemy = enemy;
    }
}
