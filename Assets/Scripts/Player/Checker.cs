using UnityEngine;

public class Checker
{
    private Collider2D _origin;
    private GroundCheckData _groundCheckData;
    private Rigidbody2D _rigidbody2D;
    public Checker(Collider2D origin, GroundCheckData data, Rigidbody2D rigidbody2D)
    {
        _origin = origin;
        _groundCheckData = data;
        _rigidbody2D = rigidbody2D;
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(_origin.bounds.center,
                                 _origin.bounds.size,
                                 _groundCheckData.CheckAngle,
                                 _groundCheckData.CheckDirection,
                                 _groundCheckData.CheckDistance,
                                 _groundCheckData.GroundLayer.value) && _rigidbody2D.velocity.y < _groundCheckData.VerticalVelocityTreshold;
    }

    public bool IsTouchingOneWayPlatform(out OneWayPlatform platform)
    {
        RaycastHit2D hitInfo = Physics2D.BoxCast(_origin.bounds.center,
                                 _origin.bounds.size,
                                 _groundCheckData.CheckAngle,
                                 _groundCheckData.CheckDirection,
                                 _groundCheckData.CheckDistance,
                                 _groundCheckData.GroundLayer.value);

        if (hitInfo.collider != null && hitInfo.collider.TryGetComponent(out OneWayPlatform p))
        {
            platform = p;
            return true;
        }

        platform = null;
        return false;
    }
}
