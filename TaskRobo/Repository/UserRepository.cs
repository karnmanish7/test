﻿using System;
using System.Linq;
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
            user.UserID = Guid.NewGuid().ToString();
            context.AppUsers.Add(user);
            context.SaveChanges();
            return 1;
        }

        // This method should be used to return boolean value. If user is authenticated successfully it should return true else return false
        public bool IsAuthenticated(AppUser user)
        {
            return context.AppUsers.Where(c => c.Email == user.Email && c.Password == user.Password).Count() == 1;
        }
    }
}