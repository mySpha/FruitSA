using FruitSA.Data.Model;

namespace FruitSA.Model.Interfaces
{
    public interface IProduct
    {
        Task<List<Product>> GetProducts(int page, int pageSize);
        Task<Product> GetProductById(int id);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product); 
        Task<Product> DeleteProduct(int id);
    }
}
