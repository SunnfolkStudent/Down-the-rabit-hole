using UnityEngine;

public class InputController : MonoBehaviour
{
    private InputActions _input;

    public Vector2 moveDirection;
    public bool JumpPressed;
    public bool JumpReleased;
    public bool interactPressed;

    private void Update()
    {
        moveDirection = _input.Player.Move.ReadValue<Vector2>();
        JumpPressed = _input.Player.Jump.WasPressedThisFrame();
        JumpReleased = _input.Player.Jump.WasReleasedThisFrame();
        interactPressed = _input.Player.Interact.WasPressedThisFrame();
    }
    
    private void Awake() { _input = new InputActions(); }
    private void OnEnable() { _input.Enable(); }
    private void OnDisable() { _input.Disable(); }
}