using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StockAppMAUI.Models;
using StockAppMAUI.Service;
using StockAppMAUI.Views;

namespace StockAppMAUI.ViewModels;

[QueryProperty(nameof(Product), "Product")]
public partial class ProductDetailViewModel : ObservableObject
{
    private AppService service = ServiceFactory.GetService();

    [ObservableProperty]
    Product product;

    [RelayCommand]
    async Task GoToEdit(Product product)
    {
        await Shell.Current.GoToAsync(nameof(ProductAddEditPage), true,
            new Dictionary<string, object>
            {
                {"Product", product}
            });
    }

    [RelayCommand]
    async Task AddProduct(Product product)
    {
        await service.AddProductAsync(product);
        await Shell.Current.GoToAsync("../..", true);
    }

    [RelayCommand]
    async Task DeleteProduct(int id)
    {
        await Shell.Current.GoToAsync("..", true);
        await service.DeleteProductAsync(id);
    }

    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..", true);
    }
}
