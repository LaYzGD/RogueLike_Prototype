using System;
using UnityEngine;

public class TargetDetection
{
    private float _detectionRange;
    private LayerMask _detectionLayer;
    private Transform _center;

    private Action<Vector2> _onEnemyDetected;
    private Action _onEnemyOutOfDetectionRange;

    public TargetDetection(float detectionRange,
                           Transform center,
                           LayerMask detectionLayer,
                           Action<Vector2> onDetectedAction,
                           Action onOutOfDetectionRange)
    {
        _detectionRange = detectionRange;
        _center = center;
        _detectionLayer = detectionLayer;
        _onEnemyDetected = onDetectedAction;
        _onEnemyOutOfDetectionRange = onOutOfDetectionRange;
    }

    public bool IsTargetDetected()
    {
        var collider = Physics2D.OverlapCircle(_center.position, _detectionRange, _detectionLayer.value);
        
        if(collider != null && collider.TryGetComponent(out Enemy enemy))
        {
            _onEnemyDetected(enemy.transform.position);
            return true;
        }

        _onEnemyOutOfDetectionRange();

        return false;
    }
}
