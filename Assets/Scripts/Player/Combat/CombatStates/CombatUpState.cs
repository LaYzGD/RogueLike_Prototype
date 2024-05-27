using System;
using UnityEngine;

public class CombatUpState : CombatState
{
    private string _animationParam;
    private bool _canChangeState;
    private Transform _horizontalCheck;
    private Transform _verticalCheck;
    private Facing _facing;
    private float _horizontalDistance;
    private float _verticalDistance;
    private LayerMask _hitLayer;

    public CombatUpState(CombatStateMachine combatStateMachine, Facing facing, Action<bool> toggleCombat, string animationParam, Transform horizontalCheck, Transform verticalCheck, CombatData data) : base(combatStateMachine, toggleCombat)
    {
        _animationParam = animationParam;
        _facing = facing;
        _horizontalCheck = horizontalCheck;
        _verticalCheck = verticalCheck;
        _horizontalDistance = data.HorrizontalCheckDistance;
        _verticalDistance = data.VerticalCheckDistance;
        _hitLayer = data.LayerMask;
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
        RaycastHit2D hit = Physics2D.Raycast(_horizontalCheck.position, new Vector2(_facing.FacingDirection, 0f), _horizontalDistance, _hitLayer);

        if (hit.collider != null)
        {
            if (!_canChangeState)
            {
                return;
            }

            CombatStateMachine.ChangeState(Combat.CombatHorizontalState);
        }

        RaycastHit2D hitUp = Physics2D.Raycast(_verticalCheck.position, Vector2.up, _verticalDistance, _hitLayer);

        if (hitUp.collider == null)
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
