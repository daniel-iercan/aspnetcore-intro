using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        [StringLength(256)]
        [Required(AllowEmptyStrings = false)]
        public string? Comment { get; set; }

        [Range(1, 5)]
        public int Stars { get; set; }

        public virtual Movie? Movie { get; set; }
    }
}
