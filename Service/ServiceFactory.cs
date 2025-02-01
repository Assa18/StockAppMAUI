namespace StockAppMAUI.Service
{
    class ServiceFactory
    {
        public static AppService GetService()
        {
            return new JSONService();
        }
    }
}
