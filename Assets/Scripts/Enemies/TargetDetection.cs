using UnityEngine;

public class TargetDetection<T>
{
    private Transform _origin;
    private LayerMask _targetLayer;

    public TargetDetection(Transform origin, LayerMask targetLayer)
    {
        _origin = origin;
        _targetLayer = targetLayer;
    }

    public bool IsPlayerInRange(float detectionRadius)
    {
        var target = Physics2D.OverlapCircle(_origin.position, detectionRadius, _targetLayer);
        if (target != null && target.TryGetComponent(out T t))
        {
            return true;
        }

        return false;
    }
}
