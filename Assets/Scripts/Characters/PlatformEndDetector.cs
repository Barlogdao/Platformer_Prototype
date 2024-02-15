using UnityEngine;

public class PlatformEndDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _platformMask;
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private Color _color;

    private readonly float _boxAngle = 0f;

    public bool IsDetected => Physics2D.OverlapBox(transform.position, _boxSize, _boxAngle, _platformMask) == null;

      private void OnDrawGizmosSelected()
    {
        Gizmos.color = _color;
        Gizmos.DrawWireCube(transform.position, _boxSize);
    }
}