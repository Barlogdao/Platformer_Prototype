using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private float _speed;
    private float _jumpForce;

    private Rigidbody2D _rigidbody2D;

    public float VerticalVelocity => _rigidbody2D.velocity.y;

    public void Initialize(float speed, float jumpForce)
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _speed = speed;
        _jumpForce = jumpForce;
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

    public void StopMove()
    {
        float horizontalVelocity = 0;
        Move(horizontalVelocity);
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
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }

    private void TurnRight()
    {
        transform.rotation = Quaternion.identity;
    }
}