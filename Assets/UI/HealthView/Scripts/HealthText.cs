using UnityEngine;
using TMPro;

namespace RB.UI
{
    public class HealthText : HealthView
    {
        [SerializeField] private TextMeshProUGUI _textLabel;

        protected override void OnHealthChanged(int targetValue)
        {
            _textLabel.text = $"{targetValue}/{MaxValue}";
        }
    }
}