using System.ComponentModel.DataAnnotations;

namespace SuperMarket.Dtos.Categories
{
    public class CreateCategoryDto
    {
        [Required]
        public required string Name { get; set; }
    }
}
