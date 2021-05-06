﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly Shows4AllMicaela.Data.Context.Shows4AllContext _context;

        public DeleteModel(Shows4AllMicaela.Data.Context.Shows4AllContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Episode = await _context.Episodes.FindAsync(id);

            if (Episode != null)
            {
                _context.Episodes.Remove(Episode);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
