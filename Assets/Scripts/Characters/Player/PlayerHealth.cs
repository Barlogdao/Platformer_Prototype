using RB.UI;
using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable, IHealable
{
    [SerializeField] HealthView _healthView;

    private Health _health;

    public event Action Hitted;

    public void Initialize(int maxHealth)
    {
        _health = new Health(maxHealth);

        _healthView.Initialize(_health);
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