using br.com.lms.samples.pocapi.core.model;
using br.com.lms.samples.pocapi.core.repository.context;
using br.com.lms.samples.pocapi.core.repository.interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace br.com.lms.samples.pocapi.core.repository
{
    public class UserRepository : IUserRepository
    {

        private readonly IServiceScope serviceScope;
        private readonly UserDatabaseContext userDatabaseContext;

        public UserRepository(IServiceProvider serviceProvider)
        {
            serviceScope = serviceProvider.CreateScope();
            userDatabaseContext = serviceScope.ServiceProvider.GetRequiredService<UserDatabaseContext>();
        }

        public async Task<bool> CreateAsync(User user)
        {
            var success = false;

            userDatabaseContext.users.Add(user);

            var numRows = await userDatabaseContext.SaveChangesAsync();

            if (numRows == 1) success = true;

            return success;
        }

        public async Task<bool> Delete(string id)
        {
            var success = false;

            var existing = Get(id);

            if (existing != null)
            {
                userDatabaseContext.users.Remove(existing);

                var numRows = await userDatabaseContext.SaveChangesAsync();

                if (numRows == 1)
                    success = true;
            }

            return success;
        }

        public User Get(string id)
        {
            var result = userDatabaseContext.users
                                .Where(x => x.Id == id)
                                .FirstOrDefault();

            return result;
        }

        public IOrderedQueryable<User> GetAll()
        {
            var result = userDatabaseContext.users
                                .OrderByDescending(x => x.Id);

            return result;
        }

        public async Task<bool> Update(User user)
        {
            var success = false;

            var existing = Get(user.Id);

            if (existing != null)
            {
                existing.Name = user.Name;
                existing.Mail = user.Mail;

                userDatabaseContext.users.Attach(existing);

                var numRows = await userDatabaseContext.SaveChangesAsync();

                if (numRows == 1)
                    success = true;
            }

            return success;
        }
    }
}
