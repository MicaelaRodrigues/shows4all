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
    public class RentedSeriesModel : PageModel
    {
        private readonly Shows4AllContext _ctx;
        public RentedSeriesModel(Shows4AllContext ctx)
        {
            _ctx = ctx;
        }

        //6*
        //criar uma variavel users para passar isto para o htlm:
        public List<Rental> Rentals { get; set; }

        public List<RentedSeriesType> RentedSeries { get; set; }

        public class RentedSeriesType
        {
            public DateTime Date { get; set; }
            public string SerieTitle { get; set; }
        }

        public void OnGet()
        {
            //RentedSeries = (
            //    from rental in _ctx.Rentals
            //    join user in _ctx.Users
            //    on rental.IdUser equals user.Id
            //    join serie in _ctx.Series
            //    on rental.IdSerie equals serie.Id
            //    where user.Id == _ctx.LoggedUser.Id
            //    group serie by new { serie.Id, serie.Title, rental.Date } into g
            //    select g.Key
            //   // select new { serie, rental }

            //    //).ToDictionary(g => g.Id, g => new { date = g.Date, title = g.Title });

            //var cenas = (new { cenas = "2" }.GetType().ToString());
            ////var group = (
            //    from item in test
            //    group item.serie by new { item.serie.Title, item.rental.Date } into g
            //    select g.Key
            //  );

            RentedSeries = (
               from rental in _ctx.Rentals
               join user in _ctx.Users
               on rental.IdUser equals user.Id
               join serie in _ctx.Series
               on rental.IdSerie equals serie.Id
               where user.Id == _ctx.LoggedUser.Id
               group serie by new { serie.Title, rental.Date } into Group
               select new
               {
                   serieTitle = Group.Key.Title,
                   date = Group.Key.Date,
               }
            )
            .OrderByDescending(g => g.date)
            .Select(x => new RentedSeriesType { SerieTitle = x.serieTitle, Date = x.date })
            .ToList();


        }


        //7*
        public void OnPost()
        {
        }
    }
}





