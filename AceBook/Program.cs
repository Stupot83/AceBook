using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AceBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Models.User.GetAll();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
