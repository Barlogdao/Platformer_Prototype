using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Coin : MonoBehaviour, IPickable
{
    [SerializeField, Min(1)] private int _value;
    [SerializeField, Min(0.1f)] private float _pickSpeed = 4f;

    private Rigidbody2D _rigidbody;

    public int Value => _value;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Push(Vector2 velocity)
    {
        _rigidbody.AddForce(velocity, ForceMode2D.Impulse);
    }

    public void Pick(Transform picker)
    {
        StartCoroutine(OnPick(picker));
    }

    private IEnumerator OnPick(Transform picker)
    {
        _rigidbody.isKinematic = true;
        _rigidbody.velocity = Vector2.zero;
        
        while (transform.position != picker.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, picker.position, _pickSpeed * Time.deltaTime);
            yield return null;
        }

        Destroy(gameObject);
    }
}