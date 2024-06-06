public class DeadState : PlayerState
{
    private string _animationTrigger;
    public DeadState(PlayerStateMachine stateMachine, string animationTrigger) : base(stateMachine)
    {
        _animationTrigger = animationTrigger;
    }

    public override void Enter()
    {
        Player.Rigidbody2D.velocity = UnityEngine.Vector2.zero;
        PlayerAnimator.ChangeAnimationState(_animationTrigger);
    }
}
