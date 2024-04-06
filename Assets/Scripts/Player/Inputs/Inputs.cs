using UnityEngine;
using UnityEngine.InputSystem;

public class Inputs : MonoBehaviour
{
    public int VerticalAimDirection { get; private set; }
    public int HorizontalMovementDirection { get; private set; }
    public bool IsJump { get; private set; }
    public bool IsAbility { get; private set; }

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
        }
    }

    public void OnAbilityInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            IsAbility = true;
        }
    }

    public void UpdateJump()
    {
        IsJump = false;
    }
}
