using School.Database.Context;
using School.Database.Entities;
using School.Infrastructure.Exceptions;

namespace School.Database.Repositories
{
    public class UsersRepository(SchoolDatabaseContext schoolDatabaseContext): BaseRepository<User>(schoolDatabaseContext)
    {
        public async Task AddAsync(User user)
        {
            schoolDatabaseContext.Users.Add(user);
            await schoolDatabaseContext.SaveChangesAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var result = schoolDatabaseContext.Users

                .Where(e => e.Email == email)
                .Where(e => e.DeletedAt == null)

                .FirstOrDefault();

            if (result == null)
                throw new ResourceMissingException("User not found");

            return result;
        }
    }
}
