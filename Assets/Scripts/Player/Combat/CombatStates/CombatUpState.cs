using System;

public class CombatUpState : CombatState
{
    private string _animationParam;
    private bool _canChangeState;

    public CombatUpState(CombatStateMachine combatStateMachine, Action<bool> toggleCombat, string animationParam) : base(combatStateMachine, toggleCombat)
    {
        _animationParam = animationParam;
    }

    public override void Enter()
    {
        _canChangeState = false;
        ToggleHorizontalCombat(false);
        Combat.WeaponAnimator.OnAnimationStarted += SetInAttack;
        Combat.WeaponAnimator.OnAnimationCompleted += SetIdle;
        Combat.WeaponAnimator.ChangeAnimationState(_animationParam, true);
    }

    private void SetInAttack()
    {
        _canChangeState = false;
    }

    private void SetIdle()
    {
        _canChangeState = true;
    }

    public override void Update()
    {
        if (Inputs.HorizontalAttackDirection != 0)
        {
            if (!_canChangeState)
            {
                return;
            }

            CombatStateMachine.ChangeState(Combat.CombatHorizontalState);
            return;
        }

        if(Inputs.VerticalAttackDirection == 0)
        {
            if (!_canChangeState)
            {
                return;
            }

            CombatStateMachine.ChangeState(Combat.CombatIdleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        Combat.WeaponAnimator.ChangeAnimationState(_animationParam, false);
        Combat.WeaponAnimator.OnAnimationStarted -= SetInAttack;
        Combat.WeaponAnimator.OnAnimationCompleted -= SetIdle;
    }
}
