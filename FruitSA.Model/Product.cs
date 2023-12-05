using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FruitSA.Data.Model
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string FieldName { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
    }
}
