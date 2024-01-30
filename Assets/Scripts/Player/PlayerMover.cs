using UnityEngine;
using UnityEngine.InputSystem;
using Controls.Input;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _jumpForce = 2f;
    [SerializeField] ObstacleChecker _groundChecker;

    private GameInput _input;
    private Rigidbody2D _rigidbody2D;
    private PlayerView _view;
    private float _horizontalInput;

    public bool IsGrounded => _groundChecker.IsTouches;

    public void Initialize(GameInput input, PlayerView view)
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = input;
        _view = view;
        _input.Player.Jump.performed += OnJump;
    }

    private void Update()
    {
        _horizontalInput = _input.Player.Move.ReadValue<float>();
        _view.SetHorizontalSpeed(_horizontalInput);
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2 ( _horizontalInput * _speed, _rigidbody2D.velocity.y);
        _view.SetVerticalSpeed(_rigidbody2D.velocity.y);
        _view.GroundCheck(IsGrounded);
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
    private void OnDestroy()
    {
        _input.Player.Jump.performed -= OnJump;
    }
}
