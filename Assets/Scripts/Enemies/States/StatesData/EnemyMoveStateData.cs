using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy/MoveState/EnemyMoveStateData", fileName = "MovetateData")]

public class EnemyMoveStateData : EnemyStateDataBase 
{
    [SerializeField] private float _movementSpeed;
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
        CheckTarget();

        if (EnemyBase.TargetDetection.CheckFront())
        {
            CheckAttackState();
            return;
        }

        if (Time.time >= _currentTime + _timeLeft)
        {
            ChangeState();
        }
    }

    public override void FixedUpdateLogic()
    {
        RigidBody2D.velocity = new Vector2(_movementSpeed * Facing.FacingDirection, RigidBody2D.velocity.y);
    }
}
