using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shows4AllMicaela.Data.Context;

namespace Shows4AllMicaela.Pages.Season
{
    public class IndexModel : PageModel
    {
        private readonly Shows4AllContext _context;

        public IndexModel(Shows4AllContext context)
        {
            _context = context;
        }

        public IList<Shows4AllMicaela.Data.Season> Season { get; set; }

        public async Task OnGetAsync()
        {
            Season = await _context.Seasons
                .Include(s => s.Episode).ToListAsync();
        }
    }
}
