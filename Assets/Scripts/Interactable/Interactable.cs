using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactable : MonoBehaviour
{
    private bool _isActivated = false;
    private BoxCollider2D _collider;
    private ContactFilter2D _contactFilter;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _contactFilter = new ContactFilter2D().NoFilter();
        OnAwake();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractor interactor) && _isActivated == false)
        {
            interactor.Interacted += InteractHandle;
            OnInteractorEnter();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractor interactor) && _isActivated == false)
        {
            interactor.Interacted -= InteractHandle;
            OnInteractorExit();
        }
    }

    protected abstract void OnInteract();

    protected virtual void OnAwake() { }

    protected virtual void OnInteractorEnter() { }

    protected virtual void OnInteractorExit() { }

    private void InteractHandle()
    {
        _isActivated = true;
        OnInteract();
        OnInteractorExit();
        UnsubscribeFromInteractors();
    }

    private void UnsubscribeFromInteractors()
    {
        List<Collider2D> colliders = new();

        _collider.OverlapCollider(_contactFilter, colliders);

        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent(out IInteractor interactor))
            {
                interactor.Interacted -= InteractHandle;
            }
        }
    }
}
