using UnityEngine;


public class Attacker : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private Vector2 _hitAreaSize;
    [SerializeField] private Color _areaColor = Color.red;

    private readonly float _hitAreaAngle = 0f;

    private  float _pushForce;
    private int _damage;

    public bool HasTargetInArea => Physics2D.OverlapBox(transform.position, _hitAreaSize, _hitAreaAngle, _targetLayer) != null;

    public void Initialize(int attackDamage, float pushForce)
    {
        _damage = attackDamage;
        _pushForce = pushForce;
    }

    public void Hit()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, _hitAreaSize, _hitAreaAngle, _targetLayer);

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent<IDamagable>(out IDamagable target) && target.IsAlive)
            {
                target.TakeDamage(_damage);
                collider.attachedRigidbody.AddForce(transform.right * _pushForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = _areaColor;
        Gizmos.DrawWireCube(transform.position, _hitAreaSize);
    }
}