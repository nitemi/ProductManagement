using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ProductManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
        //var builder = WebApplication.CreateBuilder(args);
        //var app = builder.Build();

        //app.MapGet("/", () => "Hello World!");

        //app.Run();
    }
}