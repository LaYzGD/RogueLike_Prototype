using UnityEngine;

public class HookLaunchState : AbilityState
{
    private Hook _hook;
    private bool _isGrappled;
    public HookLaunchState(PlayerStateMachine stateMachine, Hook hook) : base(stateMachine)
    {
        _hook = hook;
    }

    public override void Enter()
    {
        base.Enter();
        _isGrappled = false;
        _hook.OnReturned += FinishAbility;
        _hook.OnGrappled += Grappled;
        PlayerInputs.UseHookInput();
        _hook.Launch(Vector2.up);
    }

    private void FinishAbility()
    {
        IsAbilityDone = true;
    }

    private void Grappled()
    {
        _isGrappled = true;
    }

    public override void Update()
    {
        base.Update();
        if (_isGrappled)
        {
            if (PlayerInputs.IsHookInput)
            {
                PlayerInputs.UseHookInput();
                _hook.Ungrapple();
                FinishAbility();
            }
        }
    }

    public override void Exit()
    {
        base.Exit();
        _hook.OnReturned -= FinishAbility;
        _hook.OnGrappled -= Grappled;
    }
}
