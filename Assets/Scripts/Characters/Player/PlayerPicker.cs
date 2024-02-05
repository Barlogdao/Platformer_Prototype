using System;
using UnityEngine;

public class PlayerPicker : MonoBehaviour
{
    public event Action<IPickable> Picked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IPickable pickable))
        {
            Picked?.Invoke(pickable);
            pickable.Pick(transform);
        }
    }
}
