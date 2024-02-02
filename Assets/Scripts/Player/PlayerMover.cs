using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _jumpForce = 2f;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _originScale;

    public float VerticalVelocity => _rigidbody2D.velocity.y;

    public void Initialize()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _originScale = transform.localScale;
    }

    public void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    public void Move(float horizontalInput)
    {
        CheckDirection(horizontalInput);

        float horizontalVelocity = horizontalInput * _speed;
        Vector2 velocity = new Vector2(horizontalVelocity, VerticalVelocity);

        _rigidbody2D.velocity = velocity;
    }

    private void CheckDirection(float horizontalInput)
    {
        if (horizontalInput < 0)
        {
            TurnLeft();
        }
        else if (horizontalInput > 0)
        {
            TurnRight();
        }
    }

    private void TurnLeft()
    {
        transform.localScale = new Vector2(-_originScale.x, _originScale.y);
    }

    private void TurnRight()
    {
        transform.localScale = _originScale;
    }
}
