using System;

public class Health
{
    private int _maxValue;
    private int _currentValue;

    public Health(int maxValue)
    {
        _maxValue = maxValue;
        _currentValue = _maxValue;
    }

    public int MaxValue => _maxValue;
    public int CurrentValue => _currentValue;
    public bool IsPositive => CurrentValue > 0;

    public void Add(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException($"value can not be negative: {nameof(value)} is {value}");

        _currentValue += value;

        if (_currentValue > _maxValue)
            _currentValue = _maxValue;
    }

    public void Subtract(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException($"value can not be negative:{nameof(value)} is {value}");

        _currentValue -= value;

        if (_currentValue < 0)
            _currentValue = 0;
    }
}
