using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Polly;
using ProductToPricing.Models;
using ProductToPricing.Services;

namespace ProductToPricing
{
    public class ProductToPricing
    {
        public ProductToPricing(IProductService productService, ILoggerFactory loggerFactory)
        {
            _productService = productService;
            _logger = loggerFactory.CreateLogger<ProductToPricing>();
        }

        [Function("ProductToPricing")]
        public async Task Run([ServiceBusTrigger("swsproducttoswspricing", Connection = "P2P_ProductMessage")] Envelope message)
        {
            _logger.LogInformation($"ProductToPricing function processing: ${JsonSerializer.Serialize(message)}");

            if (message.From.ToUpper() != "PRODUCT")
                return;
            
            if (message.To.ToUpper() != "PRICING")
                return;

            if (message.Body == null)
                return;

            Product product = new Product 
            {
                ProductId = message.Body.TravelProductId,
                ProductName = message.Body.TravelProductName
            };

            switch(message.Subject.ToUpper())
            {
                case "CREATE":
                    await _productService.CreateProduct(product);
                    break;
                case "UPDATE":
                    await _productService.UpdateProduct(product);
                    break;
                case "DELETE":
                    await _productService.DeleteProduct(product.ProductId);
                    break;
            }
        }

        private readonly IProductService _productService;
        private readonly ILogger<ProductToPricing> _logger;
    }
}
