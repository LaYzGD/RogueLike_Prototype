using UnityEngine;
using UnityEngine.InputSystem;

public class Inputs : MonoBehaviour
{
    [SerializeField] private float _jumpInputHoldTime = 0.2f;
    [SerializeField] private float _attackInputHoldTime = 0.05f;
    public int VerticalAimDirection { get; private set; }
    public int HorizontalMovementDirection { get; private set; }
    public bool IsJump { get; private set; }
    public bool IsHookInput { get; private set; }

    public bool AttackInput { get; private set; }

    private float _jumpStartTime;
    private float _attackStartTime;

    private void CheckJumpInputHoldTime()
    {
        if (Time.time >= _jumpStartTime + _jumpInputHoldTime)
        {
            IsJump = false;
        }
    }

    private void CheckAttackInputHoldTime()
    {
        if (Time.time >= _attackStartTime + _attackInputHoldTime)
        {
            AttackInput = false;
        }
    }

    private void Update()
    {
        CheckJumpInputHoldTime();
        CheckAttackInputHoldTime();
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

    public void OnHookInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            IsHookInput = true;
        }
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            AttackInput = true;
            _attackStartTime = Time.time;
        }
    }

    public void UseAttackInput()
    {
        AttackInput = false;
    }

    public void UseHookInput()
    {
        IsHookInput = false;
    }

    public void UseJumpInput()
    {
        IsJump = false;
    }
}
