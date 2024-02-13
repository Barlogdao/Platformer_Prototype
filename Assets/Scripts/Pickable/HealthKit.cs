using UnityEngine;

public class HealthKit : MonoBehaviour, IPickable
{
    [SerializeField, Min(1)] private int _value;
    [SerializeField] private ParticleSystem _healParticles;

    public int Value => _value;

    public void Pick(Transform picker)
    {
        Instantiate(_healParticles, picker);

        Destroy(gameObject);
    }
}