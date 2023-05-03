using Api_With_dotnet6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_With_dotnet6.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _context;
        public ProductRepository(DatabaseContext context) {
            _context=context;
        }  
        public async Task<Product> AddProduct(Product product)
        {
            var result = _context.Add(product);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<List<Product>> DeleteProduct(int Id)
        {
            var product = await _context.Products.FindAsync(Id);

            if (product == null) throw new Exception($"Invalid Product Id {product?.Id}"); ;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return (await _context.Products.ToListAsync());
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int Id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(m => m.Id == Id);
            if (product == null)
                throw new Exception("Product not found");
            return product;
        }

        public async Task<ActionResult<Product>> UpdateProduct(Product productData)
        {
            if (productData == null || productData.Id == 0)
                throw new Exception("Bad Request");

            var product = await _context.Products.FindAsync(productData.Id);
            if (product == null)
                throw new Exception("Product Not Found");

            product.Name = productData.Name;
            product.Description = productData.Description;
            product.Price = productData.Price;

            await _context.SaveChangesAsync();
            return (product);
        }
    }
}
