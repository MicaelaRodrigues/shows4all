using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shows4AllMicaela.Data;
using Shows4AllMicaela.Data.Context;

namespace Shows4AllMicaela.Pages.serie
{
    public class DetailsModel : PageModel
    {
        private readonly Shows4AllContext _context;

        public DetailsModel(Shows4AllContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Serie Serie { get; set; }

        [BindProperty]
        public Rating Rating { get; set; }
        public User User { get; set; }

        [BindProperty]
        public Rental Rental { get; set; }
        public double RatingAverage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Serie = await _context.Series
                .Include(s => s.Season).FirstOrDefaultAsync(m => m.Id == id);

            if (Serie == null)
            {
                return NotFound();
            }

            RatingAverage = (
                from serie in _context.Series
                join rating in _context.Ratings
                on serie.Id equals rating.IdSerie // origina uma nova tabela com todas as colunas com todas os id's series
                where serie.Id == id 
                select rating
            ).Average(r => r.Stars);

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Nao tenho user logado. Apenas para testar a gravaçao das stars no user.
            Rating.IdSerie = Serie.Id;
            Rating.IdUser = 1;

            Serie = await _context.Series
                .FirstOrDefaultAsync(m => m.Id == Serie.Id);

            Rental = new Rental { 
                Price = Serie.Price,
                Date = DateTime.Now,
                IdSerie = Serie.Id,
                IdUser = 1
            };

            _context.Rentals.Add(Rental);
            await _context.SaveChangesAsync();


            return RedirectToPage("./Index");

        }

         

    }


}
