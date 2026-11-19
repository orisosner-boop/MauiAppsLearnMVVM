using System.Globalization;
using System.Windows.Input;

namespace ViewModels;

public class CalcCurrencyViewModel : BaseViewModel
{
    private const string ILS = "ILS";
    private const string USD = "USD";
    private const string EUR = "EUR";

    private readonly Dictionary<string, decimal> _rates = new()
    {
        [ILS] = 1m,
        [USD] = 3.30m,
        [EUR] = 3.80m,
    };

    private string _amount = string.Empty;
    private string _fromCurrency = ILS;
    private string _toCurrency = USD;
    private string _result = string.Empty;

    public CalcCurrencyViewModel()
    {
        Title = "ממיר מטבע";
        CurrencyOptions = new[] { ILS, USD, EUR };
        CalculateCommand = new Command(Calculate);
    }

    public string[] CurrencyOptions { get; }

    public ICommand CalculateCommand { get; }

    public string Amount
    {
        get => _amount;
        set
        {
            if (_amount != value)
            {
                _amount = value;
                OnPropertyChanged();
            }
        }
    }

    public string FromCurrency
    {
        get => _fromCurrency;
        set
        {
            if (_fromCurrency != value)
            {
                _fromCurrency = value;
                OnPropertyChanged();
            }
        }
    }

    public string ToCurrency
    {
        get => _toCurrency;
        set
        {
            if (_toCurrency != value)
            {
                _toCurrency = value;
                OnPropertyChanged();
            }
        }
    }

    public string Result
    {
        get => _result;
        set
        {
            if (_result != value)
            {
                _result = value;
                OnPropertyChanged();
            }
        }
    }

    private void Calculate()
    {
        if (!decimal.TryParse(Amount, NumberStyles.Any, CultureInfo.InvariantCulture, out var amount) || amount < 0)
        {
            Result = "הכנס סכום תקין.";
            return;
        }

        if (!_rates.TryGetValue(FromCurrency, out var fromRate) || !_rates.TryGetValue(ToCurrency, out var toRate))
        {
            Result = "בחר מטבע תקין.";
            return;
        }

        decimal converted = (amount * fromRate) / toRate;
        Result = $"{amount:0.00} {FromCurrency} = {converted:0.00} {ToCurrency}";
    }
}