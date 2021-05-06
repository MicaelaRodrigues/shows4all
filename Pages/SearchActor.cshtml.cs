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
    public class SearchActorModel : PageModel
    {

        private readonly Shows4AllContext _ctx;
        public SearchActorModel(Shows4AllContext ctx)
        {
            _ctx = ctx;
        }

        public void OnGet()
        {
        }


        [BindProperty]
        public string SearchActor { get; set; }

        //6*
        //criar uma variavel users para passar isto para o htlm:
        public List<Episode> Episodes { get; set; }

        public int MyProperty { get; set; }





        //7*
        public void OnPost()
        {

            var search = SearchActor;

            
            // consulta � base de dados: injetar o context
           // _ctx.Users.Where(u => u.District.Contains(DistrictFilter)).ToList();

            //_ctx.Episodes.Join(
            //    _ctx.Actors,
            //    actor => actor.Id,
            //    episode => episode
            //)

            //_ctx.Episodes.Where(episode => episode.IdActor.Contains(SearchActor)).ToList();
                
               


            

        }
    }
}
