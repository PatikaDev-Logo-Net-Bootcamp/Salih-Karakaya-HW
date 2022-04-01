using First.App.Business.Abstract;
using First.App.Business.Concretes;
using First.App.DataAccess.EntityFramework;
using First.App.DataAccess.EntityFramework.Repository.Abstracts;
using First.App.DataAccess.EntityFramework.Repository.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebSiteStatusCheck
{
    public class Program
    {

        static readonly IConfiguration Configuration =
            new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services
                            .AddHostedService<Worker>();
                });
    }
}
