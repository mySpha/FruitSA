using System.ComponentModel.DataAnnotations;

namespace FruitSA.API.ViewModel
{
    public class ProductViewModel
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string FieldName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
