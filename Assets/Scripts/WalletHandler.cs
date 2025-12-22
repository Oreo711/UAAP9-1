using System;
using UnityEngine;


public class WalletHandler : MonoBehaviour
{
	public event Action MoneyChanged;
	public event Action GemsChanged;
	public event Action EnergyChanged;
	public event Action ValueChanged;

	private readonly Wallet _wallet = new Wallet();

	public int MoneyCount  => _wallet.Money;
	public int GemCount    => _wallet.Gems;
	public int EnergyCount => _wallet.Energy;
	public int Value       {get; private set;} = 1;

	public void AddMoney ()
	{
		_wallet.AddMoney(Value);
		MoneyChanged?.Invoke();
	}

	public void AddGems ()
	{
		_wallet.AddGems(Value);
		GemsChanged?.Invoke();
	}

	public void AddEnergy ()
	{
		_wallet.AddEnergy(Value);
		EnergyChanged?.Invoke();
	}

	public void TakeMoney ()
	{
		_wallet.TryTakeMoney(Value);
		MoneyChanged?.Invoke();
	}

	public void TakeGems ()
	{
		_wallet.TryTakeGems(Value);
		GemsChanged?.Invoke();
	}

	public void TakeEnergy ()
	{
		_wallet.TryTakeEnergy(Value);
		EnergyChanged?.Invoke();
	}

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
