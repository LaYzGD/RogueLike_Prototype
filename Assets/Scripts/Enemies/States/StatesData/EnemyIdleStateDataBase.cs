using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy/EnemyIdleStateData", fileName = "IdleStateData")]
public class EnemyIdleStateDataBase : EnemyStateDataBase
{
    [SerializeField] private float _timeLeft;
    private float _currentTime;
    public override void EnterLogic()
    {
        base.EnterLogic();
        _currentTime = Time.time;
        RigidBody2D.velocity = Vector2.zero;
    }

    public override void UpdateLogic()
    {
        if (Time.time >= _currentTime + _timeLeft)
        {
            var nextState = EnemyBase.GetNextState();
            switch (nextState)
            {
                case EnemyStateType.Attack:
                    EnemyBase.SetNewAttackData(EnemyBase.Attacks[UnityEngine.Random.Range(0, EnemyBase.Attacks.Length)]);
                    EnemyBase.StateMachine.ChangeState(EnemyBase.AttackState);
                    break;
                case EnemyStateType.Idle:
                    EnemyBase.StateMachine.ChangeState(EnemyBase.IdleState);
                    break;
                case EnemyStateType.Move:
                    EnemyBase.StateMachine.ChangeState(EnemyBase.MoveState);
                    break;
            }
        }
    }
}
