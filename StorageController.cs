namespace SoftetherAnalyze
{

    //The Storage Controller has the Job to store every item that is given to him
    public class StorageController : BackgroundService
    {

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("storagecontroller running");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
