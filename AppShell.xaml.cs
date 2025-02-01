using StockAppMAUI.Views;

namespace StockAppMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ProductDetailsPage), typeof(ProductDetailsPage));
        }
    }
}
