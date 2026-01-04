using System;
using System.Collections.Generic;


public class Wallet
{
    public readonly Dictionary<CurrencyTypes, ReactiveVariable<int>> Currencies = new Dictionary<CurrencyTypes, ReactiveVariable<int>>
    {
        { CurrencyTypes.money, new ReactiveVariable<int>(0) },
        { CurrencyTypes.gems, new ReactiveVariable<int>(0) },
        { CurrencyTypes.energy, new ReactiveVariable<int>(0) }
    };

    public Wallet (int money, int gems, int energy)
    {
        Currencies[CurrencyTypes.money].Value  = money;
        Currencies[CurrencyTypes.gems].Value   = gems;
        Currencies[CurrencyTypes.energy].Value = energy;
    }

    public Wallet (){}

    public void AddCurrency (CurrencyTypes type, int value)
    {
        Currencies[type].Value += value;
    }

    public void TakeCurrency (CurrencyTypes type, int value)
    {
        if (value <= Currencies[type].Value)
        {
            Currencies[type].Value -= value;
            return;
        }

        Currencies[type].Value = 0;
    }
}
