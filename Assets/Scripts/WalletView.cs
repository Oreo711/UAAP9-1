using System;
using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private WalletHandler _walletHandler;

    [SerializeField] private TMP_Text _moneyCount;
    [SerializeField] private TMP_Text _gemCount;
    [SerializeField] private TMP_Text _energyCount;
    [SerializeField] private TMP_Text _value;
    [SerializeField] private Canvas   _canvas;

    private void Awake ()
    {
        _canvas.gameObject.SetActive(true);
    }

    private void Start ()
    {
        _walletHandler.MoneyChanged  += HandleMoneyChanged;
        _walletHandler.GemsChanged   += HandleGemsChanged;
        _walletHandler.EnergyChanged += HandleEnergyChanged;
        _walletHandler.ValueChanged  += HandleValueChanged;
    }

    private void HandleMoneyChanged () => SetTextToValue(_moneyCount, _walletHandler.MoneyCount);

    private void HandleGemsChanged () => SetTextToValue(_gemCount, _walletHandler.GemCount);

    private void HandleEnergyChanged () => SetTextToValue(_energyCount, _walletHandler.EnergyCount);

    private void HandleValueChanged() => SetTextToValue(_value, _walletHandler.Value);

    private void SetTextToValue (TMP_Text text, int value) => text.text = value.ToString();

    private void OnDestroy ()
    {
        _walletHandler.MoneyChanged  -= HandleMoneyChanged;
        _walletHandler.GemsChanged   -= HandleGemsChanged;
        _walletHandler.EnergyChanged -= HandleEnergyChanged;
        _walletHandler.ValueChanged  -= HandleValueChanged;
    }
}
