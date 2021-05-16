using Shows4AllMicaela.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace Shows4AllMicaela.Data.Repositories
{
    public class EpisodeRepository
    {

        private readonly Shows4AllContext _ctx;

        public EpisodeRepository(Shows4AllContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Episode> GetAsync(int id)
        {
            return await _ctx.Episodes.FindAsync(id);
        }

        public Episode AddEpisode(string title, int numberOfEpisode)
        {
            var episode = new Episode() { Title = title, NumberOfEpisode = numberOfEpisode };

            _ctx.Episodes.Add(episode);
            _ctx.SaveChanges();

            return episode;
        }


        public async Task<Episode> AddEpisodeAsync(Episode episode)
        {
            _ctx.Episodes.Add(episode);
            await _ctx.SaveChangesAsync();

            return episode;
        }

        public async Task<bool> DeleteEpisodeAsync(int id)
        {
            var episode = _ctx.Episodes.FirstOrDefault(u => u.Id == id);

            if (episode == null)
                return false;

            _ctx.Remove(episode);
            await _ctx.SaveChangesAsync();

            return true;
        }
    }
}
