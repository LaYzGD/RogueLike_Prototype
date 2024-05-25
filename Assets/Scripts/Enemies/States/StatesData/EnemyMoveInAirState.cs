using UnityEngine;


[CreateAssetMenu(menuName = "Data/Enemy/MoveState/EnemyMoveInAirStateData", fileName = "MoveInAirData")]
public class EnemyMoveInAirState : EnemyStateDataBase
{
    [SerializeField] private bool _isMovementDependsOnTime = true;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _timeLeft;
    [SerializeField] private float _frontCheckDistance;
    [SerializeField] private LayerMask _groundLayer;

    private float _currentTime;

    private bool CheckTargetBellow()
    {
        if (target == null)
        {
            return false;
        }

        if ((Vector2.Distance(new Vector2(target.position.x, EnemyBase.Body.position.y), EnemyBase.Body.position) <= EnemyBase.CloseThreshold))
        {
            return true;
        }

        return false;
    }

    public override void EnterLogic()
    {
        base.EnterLogic();
        _currentTime = Time.time;
        RigidBody2D.velocity = Vector2.zero;
    }

    private bool CheckFront()
    {
        return Physics2D.Raycast(EnemyBase.FrontCheck.position, new Vector2(Facing.FacingDirection, 0f), _frontCheckDistance, _groundLayer);
    }

    public override void UpdateLogic()
    {
        CheckTarget();

        if (target == null)
        {
            if (CheckFront())
            {
                Facing.Flip();
            }
        }

        if (CheckTargetBellow())
        {
            CheckAttackState();
            return;
        }

        if (!_isMovementDependsOnTime)
        {
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
