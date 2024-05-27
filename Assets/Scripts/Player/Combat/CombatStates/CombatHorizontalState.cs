using System;
using UnityEngine;

public class CombatHorizontalState : CombatState
{
    private Facing _facing;
    private string _animationParam;
    private bool _canFlip;
    private bool _canChangeState;
    private Transform _horizontalCheck;
    private Transform _verticalCheck;
    private float _horizontalDistance;
    private float _verticalDistance;
    private LayerMask _hitLayer;
    public CombatHorizontalState(CombatStateMachine combatStateMachine, Facing facing, Action<bool> toggleCombat, string animationParam, Transform horizontalCheck, Transform verticalCheck, CombatData data) : base(combatStateMachine, toggleCombat)
    {
        _facing = facing;
        _animationParam = animationParam;
        _horizontalCheck = horizontalCheck;
        _verticalCheck = verticalCheck;
        _horizontalDistance = data.HorrizontalCheckDistance;
        _verticalDistance = data.VerticalCheckDistance;
        _hitLayer = data.LayerMask;
    }

    public override void Enter()
    {
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
        RaycastHit2D hit = Physics2D.Raycast(_horizontalCheck.position, new Vector2(_facing.FacingDirection, 0f), _horizontalDistance, _hitLayer);

        if (hit.collider == null)
        {
            if (!_canChangeState)
            {
                return;
            }

            CombatStateMachine.ChangeState(Combat.CombatIdleState);
        }

        RaycastHit2D hitUp = Physics2D.Raycast(_verticalCheck.position, Vector2.up, _verticalDistance, _hitLayer);

        if (hitUp.collider != null)
        {
            if (!_canChangeState)
            {
                return;
            }

            CombatStateMachine.ChangeState(Combat.CombatUpState);
        }
    }

    public override void Exit()
    {
        Combat.WeaponAnimator.OnAnimationStarted -= SetInAttack;
        Combat.WeaponAnimator.OnAnimationCompleted -= SetIdle;
        Combat.WeaponAnimator.ChangeAnimationState(_animationParam, false);
    }
}
