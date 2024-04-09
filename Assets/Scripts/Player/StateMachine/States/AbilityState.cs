using UnityEngine;

public abstract class AbilityState : State
{
    private bool _isAbilityDone;
    private bool _isUnlocked;
    private Rigidbody2D _rigidbody2D;
    protected bool IsAbilityDone { get => _isAbilityDone; set => _isAbilityDone = value; }
    protected Rigidbody2D Rigidbody => _rigidbody2D;
    public AbilityState(PlayerStateMachine stateMachine, bool isUnlockedByDefault) : base(stateMachine)
    {
        _isUnlocked = isUnlockedByDefault;
        _rigidbody2D = Player.Rigidbody2D;
    }

    public override void Enter()
    {
        if (!_isUnlocked)
        {
            GoToPreviousState();
            return;
        }
        base.Enter();
        _isAbilityDone = false;
    }

    public virtual void GoToPreviousState() 
    {
        StateMachine.GoToPreviousState();
    }

    public void UnlockAbility()
    {
        _isUnlocked = true;
    }
}
