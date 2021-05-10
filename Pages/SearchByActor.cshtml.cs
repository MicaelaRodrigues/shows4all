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
    public class SearchByActorModel : PageModel
    {
        private readonly Shows4AllContext _ctx;
        public SearchByActorModel(Shows4AllContext ctx)
        {
            _ctx = ctx;
        }

        public void OnGet()
        {
        }


        [BindProperty]
        public string SearchByActor { get; set; }

        //6*
        //criar uma variavel users para passar isto para o htlm:
        public List<Episode> Episodes { get; set; }

        //7*
        public void OnPost()
        {

            var search = SearchByActor;


            Episodes = (
                from actor in _ctx.Actors
                join episodeActor in _ctx.EpisodeActors
                on actor.Id equals episodeActor.IdActor
                join episode in _ctx.Episodes
                on episodeActor.IdEpisode equals episode.Id // origina uma nova tabela com todas as colunas com todas os id's series
                where actor.Name.ToLower().Contains(SearchByActor.ToLower())
                select episode
            ).ToList();

            










        }
    }
}
