using System;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    public event Action Casted;

    public abstract void Cast();
    public abstract void StopCast();

    protected void InvokeCasedEvent()
    {
        Casted?.Invoke();
    }
}