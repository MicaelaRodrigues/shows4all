using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shows4AllMicaela.Data.Context;

namespace Shows4AllMicaela.Pages.Season
{
    public class EditModel : PageModel
    {
        private readonly Shows4AllContext _context;

        public EditModel(Shows4AllContext context)
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
           ViewData["IdEpisode"] = new SelectList(_context.Episodes, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Season).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeasonExists(Season.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SeasonExists(int id)
        {
            return _context.Seasons.Any(e => e.Id == id);
        }
    }
}
