using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.API.Models.Author
{
    public class BookCreateDto
    {
        [Required]
        [StringLength(50)]
        public string? Title { get; set; }
        [Required]
        [StringLength(250)]
        public string? Summary { get; set; }
        [Required]
        public int? Year { get; set; }
        [Required]
        public string? ISBN { get; set; }
        public decimal Price { get; set; }

    }
}
