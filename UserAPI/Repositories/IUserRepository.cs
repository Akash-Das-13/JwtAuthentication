using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;

namespace UserAPI.Repositories
{
    public interface IUserRepository
    {
        User FindUserById(string userId);
        User LogIn(string userId, string password);
        User Register(User user);

    }
}
