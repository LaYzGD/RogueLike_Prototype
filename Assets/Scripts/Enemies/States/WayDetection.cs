using UnityEngine;

public class WayDetection
{
    private float _frontCheckDistance;
    private float _downCheckDistance;
    private Transform _frontCheckPoint;
    private Transform _downCheckPoint;
    private LayerMask _ground;
    private Facing _facing;

    public WayDetection(float frontCheckDistance, float downCheckDistance, Transform frontCheckPoint, Transform downCheckPoint, LayerMask ground, Facing facing)
    {
        _frontCheckDistance = frontCheckDistance;
        _downCheckDistance = downCheckDistance;
        _frontCheckPoint = frontCheckPoint;
        _downCheckPoint = downCheckPoint;
        _ground = ground;
        _facing = facing;
    }

    public bool HasGround()
    {
        return Physics2D.Raycast(_downCheckPoint.position, Vector2.down, _downCheckDistance, _ground);
    }

    public bool HasWall()
    {
        return Physics2D.Raycast(_frontCheckPoint.position, new Vector2(_facing.FacingDirection, 0f), _frontCheckDistance, _ground);
    }
}
