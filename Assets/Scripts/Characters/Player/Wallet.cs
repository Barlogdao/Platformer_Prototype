using System;

public class Wallet
{
    private int _money;

    public Wallet(int money)
    {
        if (money < 0)
            throw new ArgumentException($"argument value {nameof(money)} can't be negative");

        _money = money;
    }

    public int Money => _money;

    public void AddMoney(int value)
    {
        _money += value;
    }

    public bool TrySpendMoney(int value)
    {
        if (_money < value)
        {
            return false;
        }
        else
        {
            _money -= value;
            return true;
        }
    }
}
