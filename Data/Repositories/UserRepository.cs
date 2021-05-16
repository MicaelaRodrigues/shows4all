using Shows4AllMicaela.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shows4AllMicaela.Data.Repositories
{
    public class UserRepository
    {
        private readonly Shows4AllContext _ctx;

        public UserRepository(Shows4AllContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<User> GetAsync(int id)
        {
            return await _ctx.Users.FindAsync(id);
        }

        public User AddUser(string name, string country, Role userType)
        {
            var user = new User() { Name = name, Country = country, UserType = userType };

            _ctx.Users.Add(user);
            _ctx.SaveChanges();

            return user;
        }


        public async Task<User> AddUserAsync(User user)
        {
            _ctx.Users.Add(user);
            await _ctx.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = _ctx.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return false;

            _ctx.Remove(user);
            await _ctx.SaveChangesAsync();

            return true;


        }
    }

}
