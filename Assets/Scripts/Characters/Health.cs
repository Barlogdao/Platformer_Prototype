using System;

public class Health
{
    public Health(int maxValue)
    {
        MaxValue = maxValue;
        CurrentValue = MaxValue;
    }

    public int MaxValue { get; }
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
        CurrentValue = Math.Clamp(CurrentValue, 0, MaxValue);
    }
}