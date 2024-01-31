using UnityEngine;

public class PlatformEndDetector : MonoBehaviour
{
    private Transform _transform;

    [SerializeField] private LayerMask _platform;
    [SerializeField, Range(0.1f,1f)] private float _detectDistance;

    private RaycastHit2D[] _hits = new RaycastHit2D[1];

    public bool IsDetected => Physics2D.RaycastNonAlloc(transform.position, -transform.up, _hits, _detectDistance) == 0;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position - new Vector3(0f,_detectDistance,0f));
    }
}
