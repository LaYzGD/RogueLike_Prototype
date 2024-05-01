using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy/BossAttackOnPlace", fileName = "AttackOnPlace")]
public class BossAttackOnPlaceData : EnemyStateDataBase
{
    public override void EnterLogic()
    {
        CharacterAnimator.OnAnimationTriggered += AnimationTriggerLogic;
        CharacterAnimator.OnAnimationCompleted += AnimationCompletedLogic;
        base.EnterLogic();
    }

    public override void AnimationTriggerLogic()
    {
        
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
        CharacterAnimator.OnAnimationTriggered -= AnimationTriggerLogic;
        CharacterAnimator.OnAnimationCompleted -= AnimationCompletedLogic;
        base.ExitLogic();
    }
}
