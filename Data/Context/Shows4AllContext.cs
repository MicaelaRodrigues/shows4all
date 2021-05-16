using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shows4AllMicaela.Data.Context
{
    public class Shows4AllContext : DbContext
    {
        public Shows4AllContext(DbContextOptions<Shows4AllContext> options) : base(options)
        {

        }


        public User LoggedUser
        {
            get
            {
                return Users.FirstOrDefault(u => u.Id == 4);
            }

            set { }
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<EpisodeActor> EpisodeActors { get; set; }




    }
}
