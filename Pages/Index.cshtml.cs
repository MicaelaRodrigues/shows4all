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

        public void OnGet()
        {
            //var name = Faker.Name.FullName();
            //var country = Faker.Country.Name();

            //UserModel = new User { Name = name, Country = country };
            //_ctx.Users.Add(UserModel);

            //_ctx.SaveChanges();

            //var episode = new Episode ()
            //{
            //    Title = "Pilot",
            //    NumberOfEpisode = 2, 




            ////};



            //_ctx.Actors.AddRange(ActorModel);

            //_ctx.SaveChanges();
        }
    }
}