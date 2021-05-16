using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shows4AllMicaela.Data;
using Shows4AllMicaela.Data.Context;

namespace Shows4AllMicaela.Pages.serie
{
    public class CreateModel : PageModel
    {
        private readonly Shows4AllContext _context;

        public CreateModel(Shows4AllContext context)
        {
            _context = context;
        }


        public IActionResult OnGet()
        {
            ViewData["SerieType"] = new SelectList(new object[]
            {
                new {Name = "Comedy", Value = "Comedy"},
                new {Name = "Horror", Value = "Horror"},
                new {Name = "Terror", Value = "Terror"},
                new {Name = "Action", Value = "Action"},
                new {Name = "Thriller", Value = "Thriller"},
                new {Name = "Romance", Value = "Romance"},
                new {Name = "Drama", Value = "Drama"},
                new {Name = "ScienceFiction", Value = "ScienceFiction"},
                new {Name = "Mistery", Value = "Mistery"},
                new {Name = "Adventure", Value = "Adventure"},
                new {Name = "Crime", Value = "Crime"},
                new {Name = "Suspense", Value = "Suspense"},
            }, "Value", "Name");

           ViewData["IdSeason"] = new SelectList(_context.Seasons, "Id", "Id");

            return Page();
        }

        [BindProperty]
        public Serie Serie { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Series.Add(Serie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
