using UnityEngine;

public class Target
{
    private float _checkDistance;
    private Transform _checkOrigin;
    private Transform _target;
    private LayerMask _targetLayer;
    private Facing _facing;

    public Transform TargetTransform => _target;

    public Target(float checkDistance, Transform checkOrigin, Facing facing, LayerMask targetLayer) 
    {
        _checkDistance = checkDistance;
        _checkOrigin = checkOrigin;
        _facing = facing;
        _targetLayer = targetLayer;
    }

    public Target(float checkRadius, Transform checkOrigin, LayerMask targetLayer)
    {
        _checkDistance = checkRadius; 
        _checkOrigin = checkOrigin;
        _target = checkOrigin;
    }

    public Target() 
    {

    }

    public void SetRawTarget(Transform target)
    {
        _target = target;
    }

    public bool CheckFront()
    {
        var rayHit = Physics2D.Raycast(_checkOrigin.position, new Vector2(_facing.FacingDirection, 0f), _checkDistance, _targetLayer);
        if (rayHit.collider != null)
        {
            _target = rayHit.collider.transform;
        }
        return rayHit;
    }

    public bool CheckInDirection(Vector2 direction)
    {
        var rayHit = Physics2D.Raycast(_checkOrigin.position, direction, _checkDistance, _targetLayer);
        if (rayHit.collider != null)
        {
            _target = rayHit.collider.transform;
        }
        return rayHit;
    }

    public bool CheckInRadius()
    {
        var circleCheck = Physics2D.OverlapCircle(_checkOrigin.position, _checkDistance, _targetLayer);
        if (circleCheck != null)
        {
            _target = circleCheck.transform;
        }
        return circleCheck;
    }
}
