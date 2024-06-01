using UnityEngine;
using UnityEngine.InputSystem;

public class Inputs : MonoBehaviour
{
    [SerializeField] private float _jumpInputHoldTime = 0.2f;
    [SerializeField] private float _dashInputHoldTime = 0.2f;
    [SerializeField] private GameObject _settingsView;
    public int VerticalMovementDirection { get; private set; }
    public int HorizontalMovementDirection { get; private set; }

    public int HorizontalAttackDirection { get; private set; }
    public int VerticalAttackDirection { get; private set; }
    public bool IsJump { get; private set; }
    public bool IsDash { get; private set; }


    private float _jumpStartTime;
    private float _dashInputStartTime;

    private void CheckJumpInputHoldTime()
    {
        if (Time.time >= _jumpStartTime + _jumpInputHoldTime)
        {
            IsJump = false;
        }
    }

    private void CheckDashInput()
    {
        if (Time.time >= _dashInputStartTime + _dashInputHoldTime)
        {
            IsDash = false;
        }
    }

    private void Update()
    {
        CheckJumpInputHoldTime();
        CheckDashInput();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();

        HorizontalMovementDirection = Mathf.RoundToInt(direction.x);
        VerticalMovementDirection = Mathf.RoundToInt(direction.y);
    }

    public void OnPauseInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _settingsView.SetActive(true);
        }
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            IsJump = true;
            _jumpStartTime = Time.time;
        }
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            IsDash = true;
            _dashInputStartTime = Time.time;
        }
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();

        HorizontalAttackDirection = Mathf.RoundToInt(direction.x);
        VerticalAttackDirection = Mathf.RoundToInt(direction.y);
    }

    public void UseJumpInput()
    {
        IsJump = false;
    }

    public void UseDashInput() => IsDash = false;
}
