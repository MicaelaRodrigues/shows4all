using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shows4AllMicaela.Data;
using Shows4AllMicaela.Data.Context;

namespace Shows4AllMicaela.Pages.episode
{
    public class DetailsModel : PageModel
    {
        private readonly Shows4AllContext _context;

        public DetailsModel(Shows4AllContext context)
        {
            _context = context;
        }

        public Episode Episode { get; set; }



        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Episode = await _context.Episodes.FirstOrDefaultAsync(m => m.Id == id);

            if (Episode == null)
            {
                return NotFound();
            }
            return Page();
        }


    }
}
