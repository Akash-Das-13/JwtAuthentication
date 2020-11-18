using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Exceptions;
using UserAPI.Models;
using UserAPI.Repositories;

namespace UserAPI.Services
{
    public class UserService : IUserService
    {
        private IUserRepository repo;

        public UserService (IUserRepository _repo)
        {
            repo = _repo;
        }
        public User LogIn(string userId, string password)
        {
            var user = repo.LogIn(userId, password);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new UserNF("Invalid User Id or Password. **Try Arain**");
            }
            
        }

        public User Register (User user)
        {
            var usv = repo.FindUserById(user.UserId);
            if (usv==null)
            {
                return repo.Register(user);
            }
            else
            {
                throw new UserAE("This User Id Already exists. Please generate Your Token.");
            }
        }
    }
}
