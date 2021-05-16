using Shows4AllMicaela.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace Shows4AllMicaela.Data.Repositories
{
    public class AtorRepository
    {
        private readonly Shows4AllContext _ctx;

        public AtorRepository(Shows4AllContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Actor> GetAsync(int id)
        {
            return await _ctx.Actors.FindAsync(id);
        }

        public Actor AddActor(string name, string country, Role userType)
        {
            var actor = new Actor() { Name = name };

            _ctx.Actors.Add(actor);
            _ctx.SaveChanges();

            return actor;
        }


        public async Task<Actor> AddActorAsync(Actor actor)
        {
            _ctx.Actors.Add(actor);
            await _ctx.SaveChangesAsync();

            return actor;
        }

        public async Task<bool> DeleteActorAsync(int id)
        {
            var actor = _ctx.Actors.FirstOrDefault(u => u.Id == id);

            if (actor == null)
                return false;

            _ctx.Remove(actor);
            await _ctx.SaveChangesAsync();

            return true;
        }
    }
}
