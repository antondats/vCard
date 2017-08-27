using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vCard.Infrastructure
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password);
    }
}
