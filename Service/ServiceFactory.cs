namespace StockAppMAUI.Service
{
    class ServiceFactory
    {
        static AppService instance;
        public static AppService GetService()
        {
            if (instance == null)
            {
                instance = new DBService();
            }
            return instance;
        }
    }
}
