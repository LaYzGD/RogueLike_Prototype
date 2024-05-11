using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy/MoveState/EnemyMoveStateData", fileName = "MovetateData")]

public class EnemyMoveStateData : EnemyStateDataBase 
{
    [SerializeField] private bool _isMovementDependsOnTime = true;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _timeLeft;
    [SerializeField] private float _groundCheckDistance;
    [SerializeField] private float _frontCheckDistance;
    [SerializeField] private LayerMask _groundLayer;

    private float _currentTime;

    public override void EnterLogic()
    {
        base.EnterLogic();
        _currentTime = Time.time;
        RigidBody2D.velocity = Vector2.zero;
    }

    private bool CheckGround()
    {
        return Physics2D.Raycast(EnemyBase.GroundCheck.position, Vector2.down, _groundCheckDistance, _groundLayer);
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
            if(!CheckGround() || CheckFront()) 
            {
                Facing.Flip();
            }
        }

        if (EnemyBase.TargetDetection.CheckFront())
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
