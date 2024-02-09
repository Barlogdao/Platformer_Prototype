using System;
using UnityEngine;

public interface IDamagable
{
    event Action Hitted;
    void TakeDamage(int damage);

    bool IsAlive {  get; }
}