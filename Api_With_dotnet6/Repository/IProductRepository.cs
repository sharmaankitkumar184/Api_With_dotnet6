using Api_With_dotnet6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_With_dotnet6.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProduct();
        Task<Product> GetProduct(int Id);
        Task<Product> AddProduct(Product product);
        Task<ActionResult<Product>> UpdateProduct(Product productData);
        Task<List<Product>> DeleteProduct(int Id);
    }
}
