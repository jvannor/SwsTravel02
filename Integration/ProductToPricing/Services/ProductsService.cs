using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProductToPricing.Models;

namespace ProductToPricing.Services;

public class ProductService : IProductService
{
    public ProductService(HttpClient httpClient, ILoggerFactory loggerFactory)
    {
        _httpClient = httpClient;
        _logger = loggerFactory.CreateLogger<ProductService>();
    }

    public async Task<Product> CreateProduct(Product p)
    {
        var content = new StringContent(JsonSerializer.Serialize(p), Encoding.UTF8, "application/json");
        var result = await _httpClient.PostAsync("api/product", content);
        var payload = await result.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Product>(payload);
    }

    public async Task DeleteProduct(int id)
    {       
        await _httpClient.DeleteAsync($"api/product/{id}");
    }

    public async Task<Product> GetProduct(int id)
    {
        var result = await _httpClient.GetAsync($"api/product/{id}");
        var payload = await result.Content.ReadAsStringAsync();
        if (!string.IsNullOrEmpty(payload))
        {
            return JsonSerializer.Deserialize<Product>(payload);
        }
        else
        {
            return null;
        }
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        var result = await _httpClient.GetAsync($"api/product/");
        var payload = await result.Content.ReadAsStringAsync();
        if (!string.IsNullOrEmpty(payload))
        {
            return JsonSerializer.Deserialize<IEnumerable<Product>>(payload);
        }
        else
        {
            return new List<Product>();
        }        
    }

    public async Task UpdateProduct(Product p)
    {
        var content = new StringContent(JsonSerializer.Serialize(p), Encoding.UTF8, "application/json");
        var result = await _httpClient.PutAsync($"api/product/{p.ProductId}", content);   
    }

    private readonly HttpClient _httpClient;
    private readonly ILogger<ProductService> _logger;
}