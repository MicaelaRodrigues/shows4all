using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Shows4AllMicaela.Data;
using Shows4AllMicaela.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shows4AllMicaela.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Shows4AllContext _ctx;

        public IndexModel(ILogger<IndexModel> logger, Shows4AllContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        public User UserModel { get; set; }
        public Actor ActorModel { get; set; }
        public Episode EpisodeModel { get; set; }
        public Rental RentalModel { get; set; }

        public void OnGet()
        {


            //var name = Faker.Name.FullName();
            //var country = Faker.Country.Name();


            //UserModel = new User { Name = name, Country = country };
            //_ctx.Users.Add(UserModel);

            //RentalModel = new Rental { Price = 10, Date = DateTime.Now, IdSerie = 3, IdUser = 3, };
            //_ctx.Rentals.Add(RentalModel);
            //_ctx.SaveChanges();

            //var episode = new Episde ()
            //{
            //    Title = "Pilot",
            //    NumberOfEpisode = 2, 

            //_ctx.SaveChanges();
        }
    }
}