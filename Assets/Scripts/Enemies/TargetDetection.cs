using UnityEngine;

public class TargetDetection<T>
{
    private Transform _origin;
    private LayerMask _targetLayer;
    private Transform _target;

    public Transform Target => _target;

    public TargetDetection(Transform origin, LayerMask targetLayer)
    {
        _origin = origin;
        _targetLayer = targetLayer;
    }

    public bool IsTargetInRange(float detectionRadius)
    {
        var target = Physics2D.OverlapCircle(_origin.position, detectionRadius, _targetLayer);
        if (target != null && target.TryGetComponent(out T t))
        {
            _target = target.transform;
            return true;
        }

        return false;
    }
}
