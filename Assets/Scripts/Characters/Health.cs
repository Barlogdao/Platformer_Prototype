using System;

public class Health
{
    private readonly int _maxValue;

    public Health(int maxValue)
    {
        _maxValue = maxValue;
        CurrentValue = _maxValue;
    }

    public int MaxValue => _maxValue;
    public int CurrentValue { get; private set; }
    public bool IsPositive => CurrentValue > 0;

    public void Add(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException($"value can not be negative: {nameof(value)} is {value}");

        CurrentValue += value;

        ClampValue();
    }

    public void Subtract(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException($"value can not be negative:{nameof(value)} is {value}");

        CurrentValue -= value;

        ClampValue();
    }

    private void ClampValue()
    {
        CurrentValue = Math.Clamp(CurrentValue, 0, _maxValue);
    }
}