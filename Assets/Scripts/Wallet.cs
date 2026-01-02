using System;
using System.Collections.Generic;


public class Wallet
{
    public event Action<CurrencyTypes, int> CurrencyChanged;

    private readonly Dictionary<CurrencyTypes, int> _currencies = new Dictionary<CurrencyTypes, int>
    {
        { CurrencyTypes.money, 0 },
        { CurrencyTypes.gems, 0 },
        { CurrencyTypes.energy, 0 }
    };

    public Wallet (int money, int gems, int energy)
    {
        _currencies[CurrencyTypes.money]  = money;
        _currencies[CurrencyTypes.gems]   = gems;
        _currencies[CurrencyTypes.energy] = energy;
    }

    public Wallet (){}

    public void AddCurrency (CurrencyTypes type, int value)
    {
        _currencies[type] += value;
        CurrencyChanged?.Invoke(type, _currencies[type]);
    }

    public bool TakeCurrency (CurrencyTypes type, int value)
    {
        if (value <= _currencies[type])
        {
            _currencies[type] -= value;
            CurrencyChanged?.Invoke(type, _currencies[type]);
            return true;
        }

        _currencies[type] = 0;
        CurrencyChanged?.Invoke(type, _currencies[type]);
        return false;
    }
}
