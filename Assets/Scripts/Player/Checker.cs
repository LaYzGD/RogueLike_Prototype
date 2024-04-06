using UnityEngine;

public class Checker
{
    private Collider2D _origin;
    private GroundCheckData _groundCheckData;
    public Checker(Collider2D origin, GroundCheckData data)
    {
        _origin = origin;
        _groundCheckData = data;
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(_origin.bounds.center,
                                 _origin.bounds.size,
                                 _groundCheckData.CheckAngle,
                                 _groundCheckData.CheckDirection,
                                 _groundCheckData.CheckDistance,
                                 _groundCheckData.GroundLayer.value);
    }
}
