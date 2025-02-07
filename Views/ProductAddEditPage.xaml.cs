using StockAppMAUI.ViewModels;

namespace StockAppMAUI.Views;

public partial class ProductAddEditPage : ContentPage
{
	public ProductAddEditPage(ProductDetailViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
}