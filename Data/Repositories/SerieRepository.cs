using Shows4AllMicaela.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shows4AllMicaela.Data.Repositories
{
    public class SerieRepository
    {
        private readonly Shows4AllContext _ctx;

        public SerieRepository(Shows4AllContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Serie> GetAsync(int id)
        {
            return await _ctx.Series.FindAsync(id);
        }

        //public Serie AddSerie(string title, double price, Genre serieType)
        //{
        //    var serie = new Serie() { Title = title, Price = price, SerieType = serieType,  };

        //    _ctx.Users.Add(user);
        //    _ctx.SaveChanges();

        //    return user;
        //}


        public async Task<Serie> AddSerieAsync(Serie serie)
        {
            // Users é uma colecao que definimos no contexto
            _ctx.Series.Add(serie);
            await _ctx.SaveChangesAsync();

            return serie;
        }

        public async Task<bool> DeleteSerieAsync(int id)
        {
            // firstordefault em vez do where
            var serie = _ctx.Series.FirstOrDefault(u => u.Id == id);

            if (serie == null)
                return false;

            _ctx.Remove(serie);
            await _ctx.SaveChangesAsync();

            return true;


        }

    }
}
