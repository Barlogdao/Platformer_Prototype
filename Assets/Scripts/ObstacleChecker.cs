using UnityEngine;

public class ObstacleChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _obstacle;
    [SerializeField] private Vector2 _boxSize;
    
    private float _boxAngle = 0f;

    public bool IsTouches { get;private set; }

    private void Update()
    {
        bool isTouchObstacle = Physics2D.OverlapBox(transform.position, _boxSize, _boxAngle, _obstacle) != null;
        IsTouches = isTouchObstacle;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, _boxSize);
    }
}
