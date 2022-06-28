using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.API.Models.Book
{
    public class BookCreateDto
    {
        [Required]
        [StringLength(50)]
        public string? Title { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 10)]
        public string? Summary { get; set; }
        [Required]
        [Range(1800, int.MaxValue)]
        public int? Year { get; set; }
        [Required]
        public string? ISBN { get; set; }
        public decimal Price { get; set; }

    }
}
