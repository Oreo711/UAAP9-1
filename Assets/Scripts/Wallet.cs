using System;

public class Wallet
{
    public int Money {get; private set;}
    public int Gems {get; private set;}
    public int Energy {get; private set;}

    public void AddMoney (int value) => Money += value;

    public void AddGems (int value) => Gems += value;

    public void AddEnergy (int value) => Energy += value;

    public bool TryTakeMoney (int value)
    {
        if (value <= Money)
        {
            Money -= value;
            return true;
        }

        return false;
    }

    public bool TryTakeGems (int value)
    {
        if (value <= Gems)
        {
            Gems -= value;
            return true;
        }

        return false;
    }

    public bool TryTakeEnergy (int value)
    {
        if (value <= Energy)
        {
            Energy -= value;
            return true;
        }

        return false;
    }
}
