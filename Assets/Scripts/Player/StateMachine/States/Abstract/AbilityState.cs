using UnityEngine;

public abstract class AbilityState : PlayerState
{
    private bool _isAbilityDone;
    private Rigidbody2D _rigidbody2D;
    protected bool IsAbilityDone { get => _isAbilityDone; set => _isAbilityDone = value; }
    protected Rigidbody2D Rigidbody => _rigidbody2D;
    public AbilityState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        _rigidbody2D = Player.Rigidbody2D;
    }

    public override void Enter()
    {
        base.Enter();
        _isAbilityDone = false;
    }

    public override void Update()
    {
        base.Update();
        if (_isAbilityDone)
        {
            if (Player.Checker.IsGrounded()) 
            {
                StateMachine.ChangeState(Player.IdleState);
                return;
            }

            StateMachine.ChangeState(Player.InAirState);
        }
    }
}
