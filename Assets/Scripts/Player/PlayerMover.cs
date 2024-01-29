using UnityEngine;
using GameInput;
using UnityEngine.InputSystem;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _jumpForce = 2f;

    private GameControls _gameControls;
    private Rigidbody2D _rigidbody2D;
    private float _velocity;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _gameControls = new GameControls();
    }

    private void OnEnable()
    {
        _gameControls.Enable();
        _gameControls.Gameplay.Jump.performed += OnJump;
    }

    private void Update()
    {
        _velocity = _gameControls.Gameplay.Move.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2 ( _velocity * _speed, _rigidbody2D.velocity.y);
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void OnDisable()
    {
        _gameControls.Disable();
    }
}
