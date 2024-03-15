using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Reviews
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; } = default!;
        public IList<Review> Review { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? movieId)
        {
            var movie = await _context.Movie
                .Include(m => m.Reviews)
                .FirstOrDefaultAsync(m => m.Id == movieId);

            if (movie == null)
            {
                return NotFound();
            }

            Movie = movie;
            Review = movie.Reviews!.ToList();
            return Page();
        }
    }
}
