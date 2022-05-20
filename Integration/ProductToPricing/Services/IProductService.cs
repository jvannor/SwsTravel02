using System.Collections.Generic;
using System.Threading.Tasks;
using ProductToPricing.Models;

namespace ProductToPricing.Services;

public interface IProductService
{
    Task<Product> CreateProduct(Product p);

    Task DeleteProduct(int id);

    Task<Product> GetProduct(int id);

    Task<IEnumerable<Product>> GetProducts();

    Task UpdateProduct(Product p);
}