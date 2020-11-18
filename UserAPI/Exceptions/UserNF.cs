using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.Exceptions
{
    public class UserNF:ApplicationException
    {
        public UserNF(string msg) : base(msg) { }
    }
}
