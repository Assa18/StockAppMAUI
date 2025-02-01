using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StockAppMAUI.Models;
using StockAppMAUI.Service;
using StockAppMAUI.Views;

namespace StockAppMAUI.ViewModels;
public partial class ProductsViewModel : ObservableObject
{
    private AppService service;

    public ObservableCollection<Product> Products { get; } = new();

    public ProductsViewModel() 
    {
        service = ServiceFactory.GetService();
    }

    [RelayCommand]
    async Task GetProductsAsync()
    {
        if (Products.Count != 0)
        {
            Products.Clear();
        }

        var products = await service.LoadProductsAsync();

        if (products == null)
        {
            return;
        }

        foreach (var product in products)
        {
            Products.Add(product);
        }
    }

    [RelayCommand]
    async Task GoToDetails(Product product)
    {
        if (product == null)
            return;

        await Shell.Current.GoToAsync(nameof(ProductDetailsPage), true,
            new Dictionary<string, object>
            {
                {"Product", product }
            });
    }
}
