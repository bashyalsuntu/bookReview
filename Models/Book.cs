using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BookReviewApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string Author { get; set; }

        public string Genre { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public decimal AverageRating { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
