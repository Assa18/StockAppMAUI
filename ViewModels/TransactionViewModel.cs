using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StockAppMAUI.Models;
using StockAppMAUI.Service;
using StockAppMAUI.Views;
using System.Collections.ObjectModel;

namespace StockAppMAUI.ViewModels;

public partial class TransactionViewModel : ObservableObject
{
    private AppService service;

    private Color[] colors;

    public ObservableCollection<TransactionDisplayModel> Transactions { get; } = new();

    public TransactionViewModel()
    {
        service = ServiceFactory.GetService();
        colors = new Color[4];
        colors[0] = new Color(250, 244, 211);
        colors[1] = new Color(154, 196, 248);
        colors[2] = new Color(217, 233, 252);
        colors[3] = new Color(217, 233, 252);
    }

    [RelayCommand]
    async Task GoToDetails(TransactionDisplayModel displayModel)
    {
        if (displayModel == null)
            return;

        await Shell.Current.GoToAsync(nameof(TransactionDetailPage), true,
            new Dictionary<string, object>
            {
                {"Transaction", displayModel }
            });
    }

    [RelayCommand]
    async Task GetAllTransactionsAsync()
    {
        if (Transactions.Count > 0)
            Transactions.Clear();

        var transactions = await service.LoadAllTransactionsAsync();

        if (transactions == null)
            return;

        var products = await service.LoadProductsAsync();

        foreach (var transaction in transactions)
        {
            string pName = products.Find(p => p.PID == transaction.PID).Name;

            Transactions.Add(new TransactionDisplayModel()
            {
                ProductName = pName,
                ProductPrice = 0,
                Transaction = transaction,
                color = colors[(int)transaction.Type]
            });
        }
    }
}
