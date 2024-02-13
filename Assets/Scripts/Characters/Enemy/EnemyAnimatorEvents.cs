using System;
using UnityEngine;

public class EnemyAnimatorEvents : MonoBehaviour
{
    public event Action AttackEnded;
    public event Action AttackHits;

    public void OnAttackEnded()
    {
        AttackEnded?.Invoke();
    }

    public void OnAttackHits()
    {
        AttackHits?.Invoke();
    }
}