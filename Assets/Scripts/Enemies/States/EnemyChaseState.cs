using UnityEngine;

public class EnemyChaseState : EnemyState
{
    private bool _isTargetDetected;
    public EnemyChaseState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void DoChecks()
    {
        base.DoChecks();
        _isTargetDetected = Enemy.TargetDetection.IsPlayerInRange(5f);
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
        Rigidbody2D.velocity = new Vector2(Enemy.Facing.FacingDirection * 7f, 0f);
    }
}
