using CommunityToolkit.Mvvm.ComponentModel;
using StockAppMAUI.Models;

namespace StockAppMAUI.ViewModels;

[QueryProperty(nameof(Product), "Product")]
public partial class ProductDetailViewModel : ObservableObject
{
    [ObservableProperty]
    Product product;
}
