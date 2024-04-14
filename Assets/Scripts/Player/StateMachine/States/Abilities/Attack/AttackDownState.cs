using UnityEngine;

public class AttackDownState : AttackState
{
    private AttackDownData _data;
    public AttackDownState(PlayerStateMachine stateMachine, AttackDownData data, string animationParameter) : base(stateMachine, animationParameter)
    {
        _data = data;
    }

    protected override void ChangeRigidbodyBehaviour()
    {
        Rigidbody2D.velocity = Vector2.zero;
    }

    protected override void EnableHitbox()
    {
        base.EnableHitbox();
        Rigidbody2D.velocity = new Vector2(_data.MovementSpeed * Player.FacingDirection, 0f);
    }


}
