using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;

namespace UserAPI.Services
{
    public interface IUserService
    {
        User LogIn(string userId, string password);
        User Register  (User user);
    }
}
