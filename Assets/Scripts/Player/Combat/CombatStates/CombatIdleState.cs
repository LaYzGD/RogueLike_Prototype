using System;

public class CombatIdleState : CombatState
{
    private string _animationParam;
    public CombatIdleState(CombatStateMachine combatStateMachine, Action<bool> toggleCombat, string animationParam) : base(combatStateMachine, toggleCombat)
    {
        _animationParam = animationParam;
    }

    public override void Enter()
    {
        Combat.WeaponAnimator.ChangeAnimationState(_animationParam, true);
        ToggleHorizontalCombat(false);
    }

    public override void Update()
    {
        if(Inputs.HorizontalAttackDirection != 0)
        {
            CombatStateMachine.ChangeState(Combat.CombatHorizontalState);
            return;
        }

        if (Inputs.VerticalAttackDirection == 1)
        {
            CombatStateMachine.ChangeState(Combat.CombatUpState);
        }
    }

    public override void Exit()
    {
        Combat.WeaponAnimator.ChangeAnimationState(_animationParam, false);
    }
}
