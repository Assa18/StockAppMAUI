using StockAppMAUI.ViewModels;

namespace StockAppMAUI.Views;

public partial class ProductPage : ContentPage
{
	public ProductPage(ProductsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}