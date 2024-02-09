using System;
using UnityEngine;

public class EnemyAnimatorEvents : MonoBehaviour
{
    public event Action AttackEnded;

    public void OnAttackEnded()
    {
        AttackEnded?.Invoke();
    }
}