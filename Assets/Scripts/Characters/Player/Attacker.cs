using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Attacker : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayer;

    private int _damage;
    private BoxCollider2D _boxCollider;

    public void Initialize(int attackDamage)
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _boxCollider.includeLayers = _targetLayer;
        _damage = attackDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamagable>(out IDamagable target))
        {
            if (target.IsAlive)
            {
                target.TakeDamage(_damage);
            }
        }
    }
}
