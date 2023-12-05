using FruitSA.Data.Model;

namespace FruitSA.Model.Interfaces
{
    public interface ICategory
    {
        Task<Category> AddCategory(Category category);
        Task<List<Category>> GetCategories();
        Task<Category> UpdateCategory(Category category);
        Task<Category> GetCategoryById(int id);

    }
}
