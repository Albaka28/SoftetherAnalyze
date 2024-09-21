namespace SoftetherAnalyze
{
    public class Program
    {
        public static void Main(string[] args)
        {

                IHost StorageService = Host.CreateDefaultBuilder(args)
                    .ConfigureServices(services =>
                    {
                        services.AddHostedService<StorageController>();
                    })
                    .Build();

                StorageService.RunAsync();

                IHost AnaMasterService = Host.CreateDefaultBuilder(args)
                    .ConfigureServices(services =>
                    {
                        services.AddHostedService<AnaMaster>();
                    })
                    .Build();

                AnaMasterService.RunAsync();
            Console.ReadLine();
        }
    }
}