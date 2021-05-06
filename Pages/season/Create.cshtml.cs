using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shows4AllMicaela.Data;
using Shows4AllMicaela.Data.Context;

namespace Shows4AllMicaela.Pages.Season
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
        ViewData["IdEpisode"] = new SelectList(_context.Episodes, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Shows4AllMicaela.Data.Season Season { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Seasons.Add(Season);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
