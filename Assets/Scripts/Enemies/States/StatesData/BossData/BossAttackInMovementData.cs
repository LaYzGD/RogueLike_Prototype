using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy/BossAttackInMovement", fileName = "AttackInMovement")]
public class BossAttackInMovementData : EnemyStateDataBase
{
    [SerializeField] private float _movementSpeed;
    public override void EnterLogic()
    {
        CharacterAnimator.OnAnimationStarted += AnimationStartedLogic;
        CharacterAnimator.OnAnimationTriggered += AnimationTriggerLogic;
        CharacterAnimator.OnAnimationCompleted += AnimationCompletedLogic;
        base.EnterLogic();
    }

    private void AnimationStartedLogic() 
    {
        RigidBody2D.velocity = new Vector2(_movementSpeed, RigidBody2D.velocity.y);
        Debug.Log(RigidBody2D.velocity);
    }

    public override void AnimationTriggerLogic()
    {
        RigidBody2D.velocity = Vector2.zero;
    }

    public override void AnimationCompletedLogic()
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

    public override void ExitLogic()
    {
        CharacterAnimator.OnAnimationStarted -= AnimationStartedLogic;
        CharacterAnimator.OnAnimationTriggered -= AnimationTriggerLogic;
        CharacterAnimator.OnAnimationCompleted -= AnimationCompletedLogic;
        base.ExitLogic();
    }
}
