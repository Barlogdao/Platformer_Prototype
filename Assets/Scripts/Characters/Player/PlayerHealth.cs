using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    private Health _health;

    public event Action Hitted;

    public void Initialize(int maxHealth)
    {
        _health = new Health(maxHealth);
    }

    public bool IsAlive => _health.IsPositive;
    public int Value => _health.CurrentValue;

    public void Heal(int value)
    {
        _health.Add(value);
    }

    public void TakeDamage(int damage)
    {
        _health.Subtract(damage);
        Hitted?.Invoke();
    }
}