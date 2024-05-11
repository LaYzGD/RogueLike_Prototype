using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy/Attacks/BossAttackOnPlace", fileName = "AttackOnPlace")]
public class BossAttackOnPlaceData : EnemyStateDataBase
{
    [SerializeField] private bool _isShootingProjectiles;
    [SerializeField] private ProjectileData _projectileData;
    public override void EnterLogic()
    {
        RigidBody2D.velocity = Vector2.zero;
        if (_isShootingProjectiles) 
        {
            EnemyBase.Spawner.Initialize(_projectileData);
        }

        CharacterAnimator.OnAnimationTriggered += AnimationTriggerLogic;
        CharacterAnimator.OnAnimationCompleted += AnimationCompletedLogic;
        base.EnterLogic();
    }

    public override void AnimationTriggerLogic()
    {
        if (_isShootingProjectiles) 
        {
            EnemyBase.Spawner.SpawnProjectile(new Vector2(EnemyBase.Facing.FacingDirection, 0f), EnemyBase.Body.rotation);
        }
        else
        {
            CheckTarget();
        }
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
