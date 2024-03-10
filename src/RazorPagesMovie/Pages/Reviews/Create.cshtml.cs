using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Reviews
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public CreateModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? movieId)
        {
            if (movieId == null)
            {
                return NotFound();
            }

            var movie = _context.Movie.Find(movieId);
            if (movie == null)
            {
                return NotFound();
            }

            Movie = movie;
            return Page();
        }

        public Movie Movie { get; set; } = default!;

        [BindProperty]
        public Review Review { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reviews.Add(Review);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index", new { movieId = Review.MovieId });
        }
    }
}
