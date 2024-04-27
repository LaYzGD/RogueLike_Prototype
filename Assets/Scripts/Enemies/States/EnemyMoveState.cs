using UnityEngine;

public class EnemyMoveState : EnemyState
{
    private WayDetection _wayDetection;
    private bool _hasWay;
    private float _speed;
    public EnemyMoveState(EnemyStateMachine stateMachine, WayDetection wayDetection, float speed) : base(stateMachine)
    {
        _wayDetection = wayDetection;
        _speed = speed;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        _hasWay = _wayDetection.HasWay();
    }

    public override void Update()
    {
        base.Update();
        DoChecks();
        if (!_hasWay) 
        {
            Enemy.Facing.Flip();
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        Rigidbody2D.velocity = new Vector2(Enemy.Facing.FacingDirection * _speed, 0f);
    }
}
