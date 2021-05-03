﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shows4AllMicaela.Data;
using Shows4AllMicaela.Data.Context;

namespace Shows4AllMicaela.Pages.episode
{
    public class CreateModel : PageModel
    {
        private readonly Shows4AllMicaela.Data.Context.Shows4AllContext _context;

        public CreateModel(Shows4AllMicaela.Data.Context.Shows4AllContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IdActor"] = new SelectList(_context.Actors, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Episode Episode { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Episodes.Add(Episode);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}