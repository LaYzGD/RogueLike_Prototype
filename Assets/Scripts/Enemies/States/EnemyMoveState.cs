using UnityEngine;

public class EnemyMoveState : EnemyState
{
    private WayDetection _wayDetection;
    private bool _hasGround;
    private bool _hasWall;
    private float _speed;
    private float _detectionRange;
    private bool _isTargetDetected;
    private string _animationParam;
    private EnemyBehaviourType _enemyBehaviourType;
    public EnemyMoveState(EnemyStateMachine stateMachine, WayDetection wayDetection, float speed, float detectionRange, string animationParam, EnemyBehaviourType type) : base(stateMachine)
    {
        _wayDetection = wayDetection;
        _detectionRange = detectionRange;
        _speed = speed;
        _animationParam = animationParam;
        _enemyBehaviourType = type;
    }

    public override void Enter()
    {
        base.Enter();
        DoChecks();
        Enemy.Animator.ChangeAnimationState(_animationParam, true);
    }

    public override void DoChecks()
    {
        base.DoChecks();
        _hasGround = _wayDetection.HasGround();
        _hasWall = _wayDetection.HasWall();
        _isTargetDetected = Enemy.TargetDetection.IsTargetInRange(_detectionRange);
        
        if (_hasWall || !_hasGround)
        {
            Enemy.Facing.Flip();
        }

        if (_isTargetDetected)
        {
            if (_enemyBehaviourType == EnemyBehaviourType.Chase)
            {
                StateMachine.ChangeState(Enemy.ChaseState);
                return;
            }

            if (_enemyBehaviourType == EnemyBehaviourType.Attack)
            {
                StateMachine.ChangeState(Enemy.AttackState);
            }
        }
    }

    public override void Update()
    {
        base.Update();
        DoChecks();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        Rigidbody2D.velocity = new Vector2(Enemy.Facing.FacingDirection * _speed, Rigidbody2D.velocity.y);
    }

    public override void Exit()
    {
        base.Exit();
        Enemy.Animator.ChangeAnimationState(_animationParam, false);
    }
}
