using System.ComponentModel.DataAnnotations;

namespace BookReviewApp.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(1000)]
        public string Comment { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }
    }
}
