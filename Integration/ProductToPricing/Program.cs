using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Configuration;
using Polly;
using ProductToPricing.Models;
using ProductToPricing.Services;

namespace ProductToPricing
{
    public class Program
    {
        public static void Main()
        {
            Random jiterrer = new Random();

            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(services => services.AddHttpClient<IProductService, ProductService>(client =>
                    client.BaseAddress = new Uri(Environment.GetEnvironmentVariable("P2P_PricingService")))
                    .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(
                        5,
                        retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                                        + TimeSpan.FromMilliseconds(jiterrer.Next(0, 1000))
                    )))
                .Build();

            host.Run();
        }
    }
}