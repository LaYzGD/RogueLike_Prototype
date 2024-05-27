using System;
using UnityEngine;

public class CombatIdleState : CombatState
{
    private string _animationParam;
    private Transform _horizontalCheck;
    private Transform _verticalCheck;
    private float _horizontalDistance;
    private float _verticalDistance;
    private LayerMask _hitLayer;
    private Facing _facing;
    public CombatIdleState(CombatStateMachine combatStateMachine, Facing facing, Action<bool> toggleCombat, string animationParam, Transform horizontalCheck, Transform verticalCheck, CombatData data) : base(combatStateMachine, toggleCombat)
    {
        _animationParam = animationParam;
        _verticalCheck = verticalCheck;
        _facing = facing;
        _horizontalCheck = horizontalCheck;
        _horizontalDistance = data.HorrizontalCheckDistance;
        _verticalDistance = data.VerticalCheckDistance;
        _hitLayer = data.LayerMask;
    }

    public override void Enter()
    {
        Combat.WeaponAnimator.ChangeAnimationState(_animationParam, true);
        ToggleHorizontalCombat(false);
    }

    public override void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(_horizontalCheck.position, new Vector2(_facing.FacingDirection, 0f), _horizontalDistance, _hitLayer);

        if (hit.collider != null)
        {
            CombatStateMachine.ChangeState(Combat.CombatHorizontalState);
            return;
        }

        RaycastHit2D hitUp = Physics2D.Raycast(_verticalCheck.position, Vector2.up, _verticalDistance, _hitLayer);

        if (hitUp.collider != null)
        {
            CombatStateMachine.ChangeState(Combat.CombatUpState);
        }
    }

    public override void Exit()
    {
        Combat.WeaponAnimator.ChangeAnimationState(_animationParam, false);
    }
}
