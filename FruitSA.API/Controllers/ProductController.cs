using FruitSA.API.ViewModel;
using FruitSA.Data.Model;
using FruitSA.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FruitSA.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productService;
        public ProductController(IProduct product)
        {
            _productService = product;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var products = await _productService.GetProducts(page, pageSize);
            return Ok(products);
        }


        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductsAsync(int productId)
        {
            try
            {
                var products = await _productService.GetProductById(productId);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] ProductViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Product product = new Product
            {
                Name = model.Name,
                Category = new Category
                {
                    CategoryId = model.CategoryId,
                },
                Description = model.Description,
                FieldName = model.FieldName,
                ImageUrl = model.ImageUrl,
                Price = model.Price

            };
            var response = await _productService.AddProduct(product);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] ProductViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                Product product = new Product
                {
                    ProductId = model.ProductId,
                    Name = model.Name,
                    Category = new Category
                    {
                        CategoryId = model.CategoryId,
                    },
                    Description = model.Description,
                    FieldName = model.FieldName,
                    ImageUrl = model.ImageUrl,
                    Price = model.Price

                };

                var updatedProduct = await _productService.UpdateProduct( product);
                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            try
            {
                var deletedItem = await _productService.DeleteProduct(productId);
                return Ok(deletedItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
