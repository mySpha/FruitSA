using FruitSA.Data;
using FruitSA.Data.Model;
using FruitSA.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FruitSA.Service
{
    public class CategoryService : ICategory
    {
        private readonly ConnectionContext _context;
        public CategoryService(ConnectionContext context)
        {
            _context = context;
        }

        public Task<Category> AddCategory(Category category)
        {
            try
            {
                _context.Entry(category).State = EntityState.Added;
                _context.Categories.Add(category);
                _context.SaveChanges();
                return Task.FromResult(category);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Task<List<Category>> GetCategories()
        {
           return _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null)
                {
                    throw new Exception("Category cannot be found");
                }
                return category;
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            try
            {
                var categoryToUpdate = await _context.Categories.FindAsync(category?.CategoryId);
                if (categoryToUpdate == null)
                {
                    throw new Exception("Category not found for update.");
                }
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.CategoryCode = category.CategoryCode;
                categoryToUpdate.IsActive = category.IsActive;
                _context.Entry(categoryToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return categoryToUpdate;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
