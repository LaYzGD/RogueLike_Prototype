using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy/Attacks/BossAttackInMovement", fileName = "AttackInMovement")]
public class BossAttackInMovementData : EnemyStateDataBase
{
    [SerializeField] private float _movementSpeed;
    public override void EnterLogic()
    {
        RigidBody2D.velocity = Vector2.zero;
        CharacterAnimator.OnAnimationStarted += AnimationStartedLogic;
        CharacterAnimator.OnAnimationTriggered += AnimationTriggerLogic;
        CharacterAnimator.OnAnimationCompleted += AnimationCompletedLogic;
        base.EnterLogic();
    }

    private void AnimationStartedLogic() 
    {
        CheckTarget();
        RigidBody2D.velocity = new Vector2(_movementSpeed * Facing.FacingDirection, RigidBody2D.velocity.y);
        Debug.Log(RigidBody2D.velocity);
    }

    public override void AnimationTriggerLogic()
    {
        RigidBody2D.velocity = Vector2.zero;
    }

    public override void AnimationCompletedLogic()
    {
        ChangeState();
    }

    public override void ExitLogic()
    {
        CharacterAnimator.OnAnimationStarted -= AnimationStartedLogic;
        CharacterAnimator.OnAnimationTriggered -= AnimationTriggerLogic;
        CharacterAnimator.OnAnimationCompleted -= AnimationCompletedLogic;
        base.ExitLogic();
    }
}
