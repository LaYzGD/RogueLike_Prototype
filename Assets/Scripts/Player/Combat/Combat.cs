using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] private float _detectionRange;
    [SerializeField] private CharacterAnimator _weaponAnimator;
    [SerializeField] private string _animationBoolParameter;
    [SerializeField] private LayerMask _enemyLayer;

    private bool _isLocked;
    private Vector2 _targetPosition;

    private TargetDetection _targetDetection;
    public TargetDetection TargetDetection => _targetDetection;

    public Vector2 TargetPosition => _targetPosition;

    private bool _canFlip;

    public bool IsLocked => _isLocked;
    public bool CanFlip => _canFlip;

    private void OnEnable()
    {
        _weaponAnimator.OnAnimationStarted += SetCanFlipFalse;
        _weaponAnimator.OnAnimationCompleted += SetCanFlipTrue;
    }

    public void Initialize()
    {
        _targetDetection = new(_detectionRange, transform, _enemyLayer, LockOnTarget, CancelTargetLock);
    }

    private void LockOnTarget(Vector2 position)
    {
        if (_isLocked) return;

        _weaponAnimator.ChangeAnimationState(_animationBoolParameter, true);
        _targetPosition = position;
        _isLocked = true;
    }

    private void SetCanFlipFalse() 
    {
        _canFlip = false;
    }

    private void SetCanFlipTrue()
    {
        _canFlip = true;
    }

    private void CancelTargetLock()
    {
        if (!_isLocked) return;

        _weaponAnimator.ChangeAnimationState(_animationBoolParameter, false);
        _isLocked = false;
    }

    private void OnDisable()
    {
        _weaponAnimator.OnAnimationStarted -= SetCanFlipFalse;
        _weaponAnimator.OnAnimationCompleted -= SetCanFlipTrue;
    }
}
