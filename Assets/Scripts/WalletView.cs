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
        _walletHandler.Wallet.CurrencyChanged += HandleCurrencyChanged;
        _walletHandler.ValueChanged           += HandleValueChanged;
    }

    private void HandleCurrencyChanged (CurrencyTypes type, int value) => SetTextToValue(type, value);

    private void HandleValueChanged () => _value.text = _walletHandler.Value.ToString();

    private void SetTextToValue (CurrencyTypes type, int value)
    {
        switch (type)
        {
            case CurrencyTypes.money:
                _moneyCount.text = value.ToString();
                break;
            case CurrencyTypes.gems:
                _gemCount.text = value.ToString();
                break;
            case CurrencyTypes.energy:
                _energyCount.text = value.ToString();
                break;
        }
    }


    private void OnDestroy ()
    {
        _walletHandler.Wallet.CurrencyChanged -= HandleCurrencyChanged;
    }
}
