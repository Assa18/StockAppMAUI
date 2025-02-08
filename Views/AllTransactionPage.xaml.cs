using StockAppMAUI.ViewModels;

namespace StockAppMAUI.Views;

public partial class AllTransactionPage : ContentPage
{
	public AllTransactionPage(TransactionViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}