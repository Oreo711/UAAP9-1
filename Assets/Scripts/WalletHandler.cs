using System;
using UnityEngine;


public class WalletHandler : MonoBehaviour
{
	public Wallet Wallet {get;} = new Wallet();

	public ReactiveVariable<int> Step {get;} = new ReactiveVariable<int>(1);

	public void AddMoney() => Wallet.AddCurrency(CurrencyTypes.money, Step.Value);

	public void AddGems() => Wallet.AddCurrency(CurrencyTypes.gems, Step.Value);

	public void AddEnergy() => Wallet.AddCurrency(CurrencyTypes.energy, Step.Value);

	public void TakeMoney () => Wallet.TakeCurrency(CurrencyTypes.money, Step.Value);

	public void TakeGems() => Wallet.TakeCurrency(CurrencyTypes.gems, Step.Value);

	public void TakeEnergy() => Wallet.TakeCurrency(CurrencyTypes.energy, Step.Value);

	public void IncrementStep ()
	{
		Step.Value++;
	}

	public void DecrementStep ()
	{
		Step.Value--;

		if (Step.Value < 0)
		{
			Step.Value = 0;
		}
	}
}
