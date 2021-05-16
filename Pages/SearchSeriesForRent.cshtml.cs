using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shows4AllMicaela.Data;
using Shows4AllMicaela.Data.Context;

namespace Shows4AllMicaela.Pages
{
    public class SearchSeriesForRentModel : PageModel
    {
        private readonly Shows4AllContext _ctx;

        public SearchSeriesForRentModel(Shows4AllContext ctx)
        {
            _ctx = ctx;
        }

        //1*
        public void OnGet()
        {
        }

        //2*
        [BindProperty]
        public string SerieForRent { get; set; }

        public List<Serie> Series { get; set; }

        //7*
        public void OnPost()
        
        
        {
            Series = _ctx.Series.Where(u => u.Title.ToLower().Contains(SerieForRent.ToLower())).ToList();
        }

    }
}
