using System;

public class CombatHorizontalState : CombatState
{
    private Facing _facing;
    private string _animationParam;
    private bool _canFlip;
    private bool _canChangeState;
    public CombatHorizontalState(CombatStateMachine combatStateMachine, Action<bool> toggleCombat, Facing facing, string animationParam) : base(combatStateMachine, toggleCombat)
    {
        _facing = facing;
        _animationParam = animationParam;
    }

    public override void Enter()
    {
        if (Inputs.HorizontalAttackDirection != _facing.FacingDirection)
        {
            _facing.Flip();
        }
        _canFlip = false;
        _canChangeState = false;
        ToggleHorizontalCombat(true);
        Combat.WeaponAnimator.OnAnimationStarted += SetInAttack;
        Combat.WeaponAnimator.OnAnimationCompleted += SetIdle;
        Combat.WeaponAnimator.ChangeAnimationState(_animationParam, true);
    }

    private void SetIdle()
    {
        _canFlip = true;
        _canChangeState = true;
    }

    private void SetInAttack()
    {
        _canFlip = false;
        _canChangeState = false;
    }

    public override void Update()
    {
        if (_canFlip && Inputs.HorizontalAttackDirection != _facing.FacingDirection)
        {
            _facing.Flip();
        }

        if (Inputs.VerticalAttackDirection == 1)
        {
            if (!_canChangeState)
            {
                return;
            }

            CombatStateMachine.ChangeState(Combat.CombatUpState);
            return;
        }

        if (Inputs.HorizontalAttackDirection == 0)
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
        Combat.WeaponAnimator.OnAnimationStarted -= SetInAttack;
        Combat.WeaponAnimator.OnAnimationCompleted -= SetIdle;
        Combat.WeaponAnimator.ChangeAnimationState(_animationParam, false);
    }
}
