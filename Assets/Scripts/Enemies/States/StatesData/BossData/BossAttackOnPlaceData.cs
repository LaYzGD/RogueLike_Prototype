using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy/Attacks/BossAttackOnPlace", fileName = "AttackOnPlace")]
public class BossAttackOnPlaceData : EnemyStateDataBase
{
    public override void EnterLogic()
    {
        RigidBody2D.velocity = Vector2.zero;
        CharacterAnimator.OnAnimationTriggered += AnimationTriggerLogic;
        CharacterAnimator.OnAnimationCompleted += AnimationCompletedLogic;
        base.EnterLogic();
    }

    public override void AnimationTriggerLogic()
    {
        CheckTarget();
    }

    public override void AnimationCompletedLogic()
    {
        ChangeState();
    }

    public override void ExitLogic()
    {
        CharacterAnimator.OnAnimationTriggered -= AnimationTriggerLogic;
        CharacterAnimator.OnAnimationCompleted -= AnimationCompletedLogic;
        base.ExitLogic();
    }
}
