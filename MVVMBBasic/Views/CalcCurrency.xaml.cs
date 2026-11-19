using ViewModels;

namespace Views;

public partial class CalcCurrency : ContentPage
{
    public CalcCurrency() : this(new CalcCurrencyViewModel())
    {
    }

    public CalcCurrency(CalcCurrencyViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}