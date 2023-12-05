using FruitSA.API.ViewModel;
using FruitSA.Data.Model;
using FruitSA.Model.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FruitSA.API.Controllers
{
    [Route("api/category")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _categoryService;

        public CategoryController(ICategory category)
        {
            _categoryService = category;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Category category = new Category 
            { 
                CategoryCode = model.CategoryCode,
                IsActive = true,
                Name = model.Name,
            };
            var response = await _categoryService.AddCategory(category);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            try
            {
                var categories = await _categoryService.GetCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                Category category = new Category
                {   
                    CategoryId = model.CategoryId,
                    CategoryCode = model.CategoryCode,
                    IsActive = model.IsActive,
                    Name = model.Name,
                };
                var updatedCategory = await _categoryService.UpdateCategory(category);
                return Ok(updatedCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategory(int categoryId)
        {
            try
            {
                var categories = await _categoryService.GetCategoryById(categoryId);
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
