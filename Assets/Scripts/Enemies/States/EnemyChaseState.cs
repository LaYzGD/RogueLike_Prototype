using UnityEngine;

public class EnemyChaseState : EnemyState
{
    private WayDetection _wayDetection;
    private bool _isTargetDetected;
    private bool _isTargetInAttackRange;
    private bool _isWallInfront;
    private float _detectionRange;
    private float _attackRange;
    private float _chaseSpeed;
    private string _animationParam;
    public EnemyChaseState(EnemyStateMachine stateMachine, WayDetection wayDetection, float detectionRange, float attackRange, float speed, string animationParam) : base(stateMachine) 
    {
        _wayDetection = wayDetection;
        _detectionRange = detectionRange;
        _attackRange = attackRange;
        _chaseSpeed = speed;
        _animationParam = animationParam;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        _isTargetDetected = Enemy.TargetDetection.IsTargetInRange(_detectionRange);
        _isTargetInAttackRange = Enemy.TargetDetection.IsTargetInRange(_attackRange);
        _isWallInfront = _wayDetection.HasWall();

        if (_isTargetInAttackRange)
        {
            StateMachine.ChangeState(Enemy.AttackState);
            return;
        }

        if (_isWallInfront)
        {
            StateMachine.ChangeState(Enemy.MoveState);
            return;
        }

        if (Enemy.TargetDetection.Target.position.x > Enemy.transform.position.x && Enemy.Facing.FacingDirection < 0)
        {
            Enemy.Facing.Flip();
        }
        else if (Enemy.TargetDetection.Target.position.x < Enemy.transform.position.x && Enemy.Facing.FacingDirection > 0)
        {
            Enemy.Facing.Flip();
        }
    }

    public override void Enter()
    {
        base.Enter();
        DoChecks();
        Enemy.Animator.ChangeAnimationState(_animationParam, true);
    }

    public override void Update()
    {
        base.Update();
        DoChecks();
        if (!_isTargetDetected)
        {
            StateMachine.ChangeState(Enemy.MoveState);
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        Rigidbody2D.velocity = new Vector2(Enemy.Facing.FacingDirection * _chaseSpeed, Rigidbody2D.velocity.y);
    }

    public override void Exit()
    {
        base.Exit();
        Enemy.Animator.ChangeAnimationState(_animationParam, false);
    }
}
