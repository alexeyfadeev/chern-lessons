using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using webTemplate.Model;

namespace webTemplate.Global.Auth
{
    public interface IUserable : IIdentity
    {
        User User { get; }
    }
}
