using UnityEngine;

public class TargetDetection
{
    private float _checkDistance;
    private Transform _checkOrigin;
    private LayerMask _targetLayer;
    private Facing _facing;

    public TargetDetection(float checkDistance, Transform checkOrigin, Facing facing, LayerMask targetLayer) 
    {
        _checkDistance = checkDistance;
        _checkOrigin = checkOrigin;
        _facing = facing;
        _targetLayer = targetLayer;
    }

    public bool CheckFront()
    {
        return Physics2D.Raycast(_checkOrigin.position, new Vector2(_facing.FacingDirection, 0f), _checkDistance, _targetLayer);
    }

    public bool CheckInDirection(Vector2 direction)
    {
        bool rayHit = Physics2D.Raycast(_checkOrigin.position, direction, _checkDistance, _targetLayer);
        return rayHit;
    }
}
