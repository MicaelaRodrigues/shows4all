using Shows4AllMicaela.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace Shows4AllMicaela.Data.Repositories
{
    public class EpisodeActorRepository
    {

        private readonly Shows4AllContext _ctx;

        public EpisodeActorRepository(Shows4AllContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<EpisodeActor> GetAsync(int id)
        {
            return await _ctx.EpisodeActors.FindAsync(id);
        }

        public async Task<EpisodeActor> AddEpisodeActorAsync(EpisodeActor episodeActor)
        {
            _ctx.EpisodeActors.Add(episodeActor);
            await _ctx.SaveChangesAsync();

            return episodeActor;
        }


        public async Task<bool> DeleteEpisodeActorAsync(int id)
        {
            var episodeActor = _ctx.EpisodeActors.FirstOrDefault(u => u.Id == id);

            if (episodeActor == null)
                return false;

            _ctx.Remove(episodeActor);
            await _ctx.SaveChangesAsync();

            return true;
        }
    }

}
