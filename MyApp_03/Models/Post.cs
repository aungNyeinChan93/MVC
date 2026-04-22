using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMarket.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public Category? Category { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

    }
}
