using Shows4AllMicaela.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace Shows4AllMicaela.Data.Repositories
{
    public class SeasonRepository
    {
        private readonly Shows4AllContext _ctx;

        public SeasonRepository(Shows4AllContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Season> GetAsync(int id)
        {
            return await _ctx.Seasons.FindAsync(id);
        }

        public async Task<Season> AddSeasonAsync(Season season)
        {
            _ctx.Seasons.Add(season);
            await _ctx.SaveChangesAsync();

            return season;
        }

        public async Task<bool> DeleteSeasonAsync(int id)
        {
            var season = _ctx.Seasons.FirstOrDefault(u => u.Id == id);

            if (season == null)
                return false;

            _ctx.Remove(season);
            await _ctx.SaveChangesAsync();

            return true;
        }
    }
}
