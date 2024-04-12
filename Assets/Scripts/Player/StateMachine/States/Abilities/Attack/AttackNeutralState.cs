using UnityEngine;

public class AttackNeutralState : AttackState
{
    public AttackNeutralState(PlayerStateMachine stateMachine, string animationParameter) : base(stateMachine, animationParameter)
    {
    }

    protected override void ChangeRigidbodyBehaviour()
    {
        Rigidbody2D.velocity = Vector2.zero;
    }
}
