using UnityEngine;

public class TargetDetector : ObstacleDetector
{
    public bool TryGetTarget(out Transform target)
    {
        Collider2D obstacle = GetObstacle();
        target = null;

        if (obstacle != null)
        {
            target = obstacle.transform;
            return true;
        }

        return false;
    }
}