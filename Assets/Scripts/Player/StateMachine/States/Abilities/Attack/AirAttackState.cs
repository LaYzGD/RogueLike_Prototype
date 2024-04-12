using UnityEngine;

public class AirAttackState : AttackState
{
    private float _initialGravityScale;
    public AirAttackState(PlayerStateMachine stateMachine, string animationParameter) : base(stateMachine, animationParameter)
    {
    }

    protected override void ChangeRigidbodyBehaviour()
    {
        Rigidbody2D.velocity = Vector2.zero;
        Rigidbody2D.gravityScale = 0f;
    }

    public override void Enter()
    {
        _initialGravityScale = Rigidbody2D.gravityScale;

        base.Enter();
    }

    protected override void EnableHitbox()
    {
        base.EnableHitbox();
        Rigidbody2D.velocity = new Vector2(Player.FacingDirection * 10 * -1, 0f);
    }

    protected override void FinishAtack()
    {
        Rigidbody2D.gravityScale = _initialGravityScale;
        base.FinishAtack();
    }

    public override void Exit()
    {
        base.Exit();
        Rigidbody2D.gravityScale = _initialGravityScale;
    }
}
