using UnityEngine;

public class AttackForwardState : AttackState
{
    private AttackForwardData _data;
    public AttackForwardState(PlayerStateMachine stateMachine, AttackForwardData data, string animationParameter) : base(stateMachine, animationParameter)
    {
        _data = data;
    }

    protected override void ChangeRigidbodyBehaviour()
    {
        Rigidbody2D.velocity = new Vector2(_data.ForwardMovement * Player.FacingDirection, 0f);
    }

    protected override void FinishAtack()
    {
        base.FinishAtack();
        Rigidbody2D.velocity = Vector2.zero;
    }
}
