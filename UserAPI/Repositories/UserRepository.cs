using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;

namespace UserAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DataContext context;

        public UserRepository(DataContext _context)
        {
            context = _context;
        }
        public User FindUserById(string userId)
        {
            User user = context.Users.FirstOrDefault(u => u.UserId == userId);
            return user;
        }

        public User LogIn(string userId, string password)
        {
            User user= context.Users.FirstOrDefault(u => u.UserId == userId && u.Password == password);
            return user;
        }

        public User Register(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }
    }
}
