using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shows4AllMicaela.Data.Context;

namespace Shows4AllMicaela.Pages.Season
{
    public class DeleteModel : PageModel
    {
        private readonly Shows4AllContext _context;

        public DeleteModel(Shows4AllContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Shows4AllMicaela.Data.Season Season { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Season = await _context.Seasons
                .Include(s => s.Episode).FirstOrDefaultAsync(m => m.Id == id);

            if (Season == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Season = await _context.Seasons.FindAsync(id);

            if (Season != null)
            {
                _context.Seasons.Remove(Season);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
