using StockAppMAUI.ViewModels;

namespace StockAppMAUI.Views;

public partial class ProductDetailsPage : ContentPage
{
	public ProductDetailsPage(ProductDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}