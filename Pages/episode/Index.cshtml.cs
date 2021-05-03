using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shows4AllMicaela.Data;
using Shows4AllMicaela.Data.Context;

namespace Shows4AllMicaela.Pages.episode
{
    public class IndexModel : PageModel
    {
        private readonly Shows4AllMicaela.Data.Context.Shows4AllContext _context;

        public IndexModel(Shows4AllMicaela.Data.Context.Shows4AllContext context)
        {
            _context = context;
        }

        public IList<Episode> Episode { get;set; }

        public async Task OnGetAsync()
        {
            Episode = await _context.Episodes
                .Include(e => e.Actor).ToListAsync();
        }
    }
}
