using UnityEngine;
using UnityEngine.InputSystem;

public class Inputs : MonoBehaviour
{
    [SerializeField] private float _jumpInputHoldTime = 0.2f;
    public int VerticalAimDirection { get; private set; }
    public int HorizontalMovementDirection { get; private set; }
    public bool IsJump { get; private set; }


    private float _jumpStartTime;

    private void CheckJumpInputHoldTime()
    {
        if (Time.time >= _jumpStartTime + _jumpInputHoldTime)
        {
            IsJump = false;
        }
    }


    private void Update()
    {
        CheckJumpInputHoldTime();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();

        HorizontalMovementDirection = Mathf.RoundToInt(direction.x);
        VerticalAimDirection = Mathf.RoundToInt(direction.y);
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            IsJump = true;
            _jumpStartTime = Time.time;
        }
    }


    public void UseJumpInput()
    {
        IsJump = false;
    }
}
