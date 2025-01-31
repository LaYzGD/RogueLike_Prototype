using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy/Attacks/BossAttackOnPlace", fileName = "AttackOnPlace")]
public class BossAttackOnPlaceData : EnemyStateDataBase
{
    [SerializeField] private bool _isShootingProjectiles;
    [SerializeField] private Vector2 _projectileVector;
    [SerializeField] private ProjectileData _projectileData;
    public override void EnterLogic()
    {
        RigidBody2D.velocity = Vector2.zero;
        if (_isShootingProjectiles) 
        {
            EnemyBase.Spawner.Initialize(_projectileData);
        }

        CharacterAnimator.OnAnimationStarted += AnimationStarted;
        CharacterAnimator.OnAnimationTriggered += AnimationTriggerLogic;
        CharacterAnimator.OnAnimationCompleted += AnimationCompletedLogic;
        base.EnterLogic();
    }

    private void AnimationStarted()
    {
        EnemyBase.SetHealthImune(true);
    }

    public override void AnimationTriggerLogic()
    {
        if (_isShootingProjectiles) 
        {
            EnemyBase.Spawner.SpawnProjectile(new Vector2(_projectileVector.x * EnemyBase.Facing.FacingDirection, _projectileVector.y), EnemyBase.Body.rotation);
        }
        else
        {
            CheckTarget();
        }
    }

    public override void AnimationCompletedLogic()
    {
        EnemyBase.SetHealthImune(false);
        ChangeState();
    }

    public override void ExitLogic()
    {
        CharacterAnimator.OnAnimationStarted -= AnimationStarted;
        CharacterAnimator.OnAnimationTriggered -= AnimationTriggerLogic;
        CharacterAnimator.OnAnimationCompleted -= AnimationCompletedLogic;
        base.ExitLogic();
    }
}
