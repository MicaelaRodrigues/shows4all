using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shows4AllMicaela.Data;

namespace Shows4AllMicaela.Pages.ator
{
    public class DetailsModel : PageModel
    {
        private readonly Shows4AllMicaela.Data.Context.Shows4AllContext _context;

        public DetailsModel(Shows4AllMicaela.Data.Context.Shows4AllContext context)
        {
            _context = context;
        }

        public Actor Actor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Actor = await _context.Actors.FirstOrDefaultAsync(m => m.Id == id);

            if (Actor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
