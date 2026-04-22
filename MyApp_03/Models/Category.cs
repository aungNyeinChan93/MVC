using System.ComponentModel.DataAnnotations;

namespace SuperMarket.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public required string Name { get; set; }

        public List<Post>? Posts { get; set; }

    }
}
