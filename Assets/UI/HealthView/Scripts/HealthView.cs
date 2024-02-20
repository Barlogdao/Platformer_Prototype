using UnityEngine;

namespace RB.UI
{
    public abstract class HealthView : MonoBehaviour
    {
        private Health _health;

        protected int MaxValue => _health.MaxValue;

        public void Initialize(Health health)
        {
            _health = health;

            _health.ValueChanged += OnHealthChanged;

            PrepareView();
        }

        private void OnDestroy()
        {
            if (_health != null)
                _health.ValueChanged -= OnHealthChanged;
        }

        protected abstract void OnHealthChanged(int targetValue);

        private void PrepareView()
        {
            OnHealthChanged(_health.CurrentValue);
        }
    }
}