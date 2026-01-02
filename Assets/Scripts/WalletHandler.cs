using System;
using UnityEngine;


public class WalletHandler : MonoBehaviour
{
	public event Action ValueChanged;

	public Wallet Wallet {get;} = new Wallet();

	public int Value {get; private set;} = 1;

	public void AddMoney() => Wallet.AddCurrency(CurrencyTypes.money, Value);

	public void AddGems() => Wallet.AddCurrency(CurrencyTypes.gems, Value);

	public void AddEnergy() => Wallet.AddCurrency(CurrencyTypes.energy, Value);

	public void TakeMoney () => Wallet.TakeCurrency(CurrencyTypes.money, Value);

	public void TakeGems() => Wallet.TakeCurrency(CurrencyTypes.gems, Value);

	public void TakeEnergy() => Wallet.TakeCurrency(CurrencyTypes.energy, Value);

	public void IncrementValue ()
	{
		Value++;
		ValueChanged?.Invoke();
	}

	public void DecrementValue ()
	{
		Value--;

		if (Value < 0)
		{
			Value = 0;
		}

		ValueChanged?.Invoke();
	}
}
