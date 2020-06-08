using System;
using TaskRobo.Models;

namespace TaskRobo.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly TaskDbContext context;
        public UserRepository()
        {
            context = new TaskDbContext();
        }

        // This method should be used to save user details into database
        public int CreateUser(AppUser user)
        {
            return 0;
        }

        // This method should be used to return boolean value. If user is authenticated successfully it should return true else return false
        public bool IsAuthenticated(AppUser user)
        {
            return false;
        }
    }
}