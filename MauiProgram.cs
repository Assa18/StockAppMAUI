using Microsoft.Extensions.Logging;
using StockAppMAUI.ViewModels;
using StockAppMAUI.Views;

namespace StockAppMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<ProductsViewModel>();
            builder.Services.AddSingleton<TransactionViewModel>();

            builder.Services.AddTransient<ProductDetailViewModel>();
            builder.Services.AddSingleton<ProductDetailsPage>();

            return builder.Build();
        }
    }
}
