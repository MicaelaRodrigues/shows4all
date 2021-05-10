using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shows4AllMicaela.Data;
using Shows4AllMicaela.Data.Context;

namespace Shows4AllMicaela.Pages
{
    public class TopSeriesByRatingModel : PageModel
    {

        private readonly Shows4AllContext _ctx;

        public TopSeriesByRatingModel(Shows4AllContext ctx)
        {
            _ctx = ctx;
        }       

        [BindProperty]
        public string TopSeriesByRating { get; set; }

        //6*
        //criar uma variavel users para passar isto para o htlm:
        public List<Serie> Series { get; set; }

        public List<SerieByRating> RatingAverage { get; set; }

        public class SerieByRating
        {
            public double Stars { get; set; }
            public string SerieTitle { get; set; }
        }

        public void OnGet()
        {

            RatingAverage = (
               from serie in _ctx.Series
               join rating in _ctx.Ratings
               on serie.Id equals rating.IdSerie
               group new { rating, serie } by serie.Title into starsGroup
               select new
               {
                   serieTitle = starsGroup.Key,
                   //serieTitle = starsGroup.Select(x => x.serie.Title),
                   AverageStars = starsGroup.Average(x => x.rating.Stars),
               }
            )
            .OrderByDescending(g => g.AverageStars)
            .Take(3)
            .Select(x => new SerieByRating { SerieTitle = x.serieTitle, Stars = x.AverageStars })
            .ToList();       

            //RatingAverage = ((IEnumerable)groupby).Cast<object>().ToList();
        }
    }


}
