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
    public class TopSeriesByGenreModel : PageModel
    {

        private readonly Shows4AllContext _ctx;

        public TopSeriesByGenreModel(Shows4AllContext ctx)
        {
            _ctx = ctx;
        }

        [BindProperty]
        public string SearchGenre { get; set; }

        public List<SerieByGenre> SerieByGenres { get; set; }

        public class SerieByGenre
        {
            public string Genre { get; set; }
            public string SerieTitle { get; set; }
            public double Stars { get; set; }
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            //var test = (
            //    from serie in _ctx.Series
            //    select serie
            //).Select(x => x.SerieType);

           
            
               

            SerieByGenres = (
                from serie in _ctx.Series.AsEnumerable()
                join rating in _ctx.Ratings
                on serie.Id equals rating.IdSerie         
                group rating by new { serie.Title, serie.SerieType, rating } into starsGroup
                select new
                 {
                     SerieTitle = starsGroup.Key.Title,
                     Genre = starsGroup.Key.SerieType,
                     Stars = starsGroup.Average(x => x.Stars),                    
                 }
            )
            .Where(x => x.ToString().ToLower().Contains(SearchGenre.ToLower()))
            .OrderByDescending(g => g.Stars)
            .Take(3)
            .Select(x => new SerieByGenre { SerieTitle = x.SerieTitle, Stars = x.Stars, Genre = x.Genre.ToString() })
            .ToList();
        }
        

    }
}
