using System;
using UnityEngine;

public class PlayerAnimatorEvents : MonoBehaviour
{
    public event Action AttackEnded;
    public event Action AttackHits;
    public event Action HitEnded;

    public void OnHitEnded()
    {
        HitEnded?.Invoke();
    }

    public void OnAttackEnded()
    {
        AttackEnded?.Invoke();
    }

    public void OnAttackHits()
    {
        AttackHits?.Invoke();
    }
}