using FruitSA.Data;
using FruitSA.Data.Model;
using FruitSA.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FruitSA.Service
{
    public class ProductService : IProduct
    {
        private readonly ConnectionContext _context;
        public ProductService(ConnectionContext context)
        {
            _context = context;
        }
        public async Task<Product> AddProduct(Product product)
        {
            try
            {
                if (product == null)
                {
                    throw new Exception("Product cannot be null");
                }

                var category = _context.Categories.Find(product?.Category.CategoryId);

                if (category == null)
                {
                    throw new Exception("Category cannot be found");
                }
                product.Category = category;
                product.ProductCode = await GenerateProductCode();
                _context.Entry(product).State = EntityState.Added;
                _context.Products.Add(product);
                _context.SaveChanges();
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> DeleteProduct(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    throw new Exception("Product not found");
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    throw new Exception("Product cannot be found");
                }

                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Task<List<Product>> GetProducts(int page, int pageSize)
        {
            return _context.Products
                .Include(x => x.Category)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)  
                .ToListAsync();
        }



        public async Task<Product> UpdateProduct( Product product)
        {
            try
            {
                var productToUpdate = await _context.Products.FindAsync(product.ProductId);
                if (productToUpdate == null)
                {
                    throw new Exception("Product not found for update.");
                }

                var category = _context.Categories.Find(product?.Category.CategoryId);

                if (category == null)
                {
                    throw new Exception("Category cannot be found");
                }
                productToUpdate.Name = product.Name;
                productToUpdate.FieldName = product.FieldName;
                productToUpdate.Description = product.Description;
                productToUpdate.ImageUrl = product.ImageUrl;
                productToUpdate.Category = category;
                productToUpdate.Price = product.Price;
                _context.Entry(productToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return productToUpdate;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private async Task<string> GenerateProductCode()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;

            int sequentialCode = await GetNextSequentialCode(year, month);

            string productCode = $"{year}{month:D2}-{sequentialCode:D3}";

            return productCode;
        }
        private async Task<int> GetNextSequentialCode(int year, int month)
        {
            var latestSequentialCode = await _context.Products
                .Where(p => p.ProductCode != null && p.ProductCode.StartsWith($"{year}{month:D2}-"))
                .OrderByDescending(p => p.ProductCode)
                .Select(p => p.ProductCode)
                .FirstOrDefaultAsync();

            int sequentialCode = 1;
            if (latestSequentialCode != null)
            {
                string[] parts = latestSequentialCode.Split('-');
                if (parts.Length == 2 && int.TryParse(parts[1], out int existingCode))
                {
                    sequentialCode = existingCode + 1;
                }
            }

            return sequentialCode;
        }
    }
}
