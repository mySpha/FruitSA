using System.ComponentModel.DataAnnotations;

namespace FruitSA.API.ViewModel
{
    public class AddCategoryViewModel
    {
        public string Name { get; set; }

        [Required(ErrorMessage = "Category code is required.")]
        [RegularExpression("^[A-Za-z]{3}[0-9]{3}$", ErrorMessage = "Category code must be in the format ABC123.")]
        public string CategoryCode { get; set; }
    }
}
