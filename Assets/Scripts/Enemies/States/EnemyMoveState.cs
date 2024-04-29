using UnityEngine;

public class EnemyMoveState : EnemyState
{
    private WayDetection _wayDetection;
    private bool _hasWay;
    private float _speed;
    private float _detectionRange;
    private bool _isTargetDetected;
    private string _animationParam;
    public EnemyMoveState(EnemyStateMachine stateMachine, WayDetection wayDetection, float speed, float detectionRange, string animationParam) : base(stateMachine)
    {
        _wayDetection = wayDetection;
        _detectionRange = detectionRange;
        _speed = speed;
        _animationParam = animationParam;
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
        _hasWay = _wayDetection.HasWay();
        _isTargetDetected = Enemy.TargetDetection.IsTargetInRange(_detectionRange);
    }

    public override void Update()
    {
        base.Update();
        DoChecks();
        if (_isTargetDetected && _hasWay)
        {
            StateMachine.ChangeState(Enemy.ChaseState);
            return;
        }
        if (!_hasWay) 
        {
            Enemy.Facing.Flip();
        }
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
