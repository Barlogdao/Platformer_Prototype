using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _jumpForce = 2f;

    private Rigidbody2D _rigidbody2D;

    public float VerticalVelocity => _rigidbody2D.velocity.y;

    public void Initialize()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    public void Move(float horizontalInputValue)
    {
        float horizontalTranslation = horizontalInputValue * _speed * Time.deltaTime;
        Vector2 translation = new Vector2(horizontalTranslation, 0f);

        transform.Translate(translation);
        CheckDirection(horizontalInputValue);
    }

    private void CheckDirection(float horizontalInputValue)
    {
        Vector2 scale = horizontalInputValue < 0 ? new Vector2(-1f, 1f) : Vector2.one;

        transform.localScale = scale;
    }
}
