using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.Exceptions
{
    public class UserAE:ApplicationException
    {
        
        public UserAE(string msg):base(msg) { }
    }
}
