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
        _walletHandler.Wallet.Currencies[CurrencyTypes.money].Changed += HandleMoneyChanged;
        _walletHandler.Wallet.Currencies[CurrencyTypes.gems].Changed += HandleGemsChanged;
        _walletHandler.Wallet.Currencies[CurrencyTypes.energy].Changed += HandleEnergyChanged;
        _walletHandler.Step.Changed += HandleValueChanged;
    }

    private void HandleMoneyChanged (int previousValue, int newValue) => SetTextToValue(CurrencyTypes.money, newValue);

    private void HandleGemsChanged (int previousValue, int newValue) => SetTextToValue(CurrencyTypes.gems, newValue);

    private void HandleEnergyChanged (int previousValue, int newValue) => SetTextToValue(CurrencyTypes.energy, newValue);

    private void HandleValueChanged (int previousValue, int newValue) => _value.text = _walletHandler.Step.Value.ToString();

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
        _walletHandler.Wallet.Currencies[CurrencyTypes.money].Changed -= HandleMoneyChanged;
        _walletHandler.Wallet.Currencies[CurrencyTypes.gems].Changed -= HandleGemsChanged;
        _walletHandler.Wallet.Currencies[CurrencyTypes.energy].Changed -= HandleEnergyChanged;
        _walletHandler.Step.Changed -= HandleValueChanged;
    }
}
