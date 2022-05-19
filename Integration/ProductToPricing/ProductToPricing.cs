using System;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using ProductToPricing.Models;

namespace ProductToPricing
{
    public class ProductToPricing
    {
        public ProductToPricing(HttpClient client, ILoggerFactory loggerFactory)
        {
            _client = client;
            _logger = loggerFactory.CreateLogger<ProductToPricing>();
        }

        [Function("ProductToPricing")]
        public void Run([ServiceBusTrigger("swsproducttoswspricing", Connection = "ProductMessage")] Envelope message)
        {
            _logger.LogInformation($"ProductToPricing function processing: ${JsonSerializer.Serialize(message)}");

            if (message.From.ToUpper() != "PRODUCT")
                return;
            
            if (message.To.ToUpper() != "PRICING")
                return;

            switch(message.Subject.ToUpper())
            {
                case "CREATE":
                    CreatePricingProduct(message.Body);
                    break;
                case "UPDATE":
                    UpdatePricingProduct(message.Body);
                    break;
                case "DELETE":
                    DeletePricingProduct(message.Body);
                    break;
            }
        }

        private void CreatePricingProduct(TravelProduct product)
        {
            _logger.LogInformation($"CreatePricingProduct processing: ${JsonSerializer.Serialize(product)}");
        }

        private void UpdatePricingProduct(TravelProduct product)
        {
            _logger.LogInformation($"UpdatePricingProduct processing: ${JsonSerializer.Serialize(product)}");
        }

        private void DeletePricingProduct(TravelProduct product)
        {
            _logger.LogInformation($"DeletePricingProduct processing: ${JsonSerializer.Serialize(product)}");
        }

        private readonly HttpClient _client;
        private readonly ILogger _logger;
    }
}
