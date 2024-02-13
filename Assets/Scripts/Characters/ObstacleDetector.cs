using UnityEngine;

public class ObstacleDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _obstacleMask;
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private Color _color;

    private readonly float _boxAngle = 0f;

    public bool IsDetected => Physics2D.OverlapBox(transform.position, _boxSize, _boxAngle, _obstacleMask) != null;

    protected Collider2D GetObstacle => Physics2D.OverlapBox(transform.position, _boxSize, _boxAngle, _obstacleMask);

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = _color;
        Gizmos.DrawWireCube(transform.position, _boxSize);
    }
}