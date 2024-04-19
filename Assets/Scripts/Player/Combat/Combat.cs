using System;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] private CharacterAnimator _weaponAnimator;
    [SerializeField] private string _animationParameterName;

    private Inputs _inputs;
    private Action _flipAction;

    private bool _canFlip;
    private bool _isInCombat;

    public bool IsInCombat => _isInCombat;

    public void Initialize(Action flipAction, Inputs inputs)
    {
        _inputs = inputs;
        _flipAction = flipAction;
        _canFlip = true;
    }

    public void UpdateCombat(int facingDirection)
    {
        if (_inputs.HorizontalAttackDirection == 0 && _inputs.VerticalAttackDirection == 0)
        {
            _isInCombat = false;
            _weaponAnimator.ChangeAnimationState(_animationParameterName, false);
            return;
        }

        _isInCombat = true;

        _weaponAnimator.ChangeAnimationState(_animationParameterName, true);

        if (_inputs.HorizontalAttackDirection != 0 && _inputs.HorizontalAttackDirection != facingDirection && _canFlip)
        {
            _flipAction();
        }
    }
}
