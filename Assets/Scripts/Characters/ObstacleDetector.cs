using UnityEngine;

public class ObstacleDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _obstacleMask;
    [SerializeField] private Vector2 _boxSize;
    
    private float _boxAngle = 0f;

    public bool IsDetected => Physics2D.OverlapBox(transform.position, _boxSize, _boxAngle, _obstacleMask) != null;

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, _boxSize);
    }
}
