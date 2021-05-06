using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shows4AllMicaela.Data;
using Shows4AllMicaela.Data.Context;

namespace Shows4AllMicaela.Pages.serie
{
    public class EvaluateModel : PageModel
    {
        //4*
        private readonly Shows4AllContext _ctx;

        //3*
        // criar um construtotr para aceder � base de dados/context

        public EvaluateModel(Shows4AllContext ctx)
        {
            //5*
            _ctx = ctx;
        }

        //1*
        public void OnGet()
        {
        }

        //2*
        [BindProperty]
        public string Evaluate { get; set; }

        //6*
        //criar uma variavel users para passar isto para o htlm:
        public List<Serie> Series { get; set; }

        //7*
        public void OnPost()
        {
            var filtro = Evaluate;

            // consulta � base de dados: injetar o context
            _ctx.Ratings.Where(u => u.Stars != 0);
            
     
        }


    }
}
