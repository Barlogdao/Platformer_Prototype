using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _moveDuration;
    [SerializeField] private Ease _ease;
    [SerializeField] private float _delay;

    private void Start()
    {
        DOTween.Sequence()
            .AppendInterval(_delay)
            .Append(transform.DOMove(_endPoint.position, _moveDuration))
            .AppendInterval(_delay)
            .Append(transform.DOMove(transform.position, _moveDuration))
            .SetEase(_ease)
            .SetLoops(-1)
            .Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
