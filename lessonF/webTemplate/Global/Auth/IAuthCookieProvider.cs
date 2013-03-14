using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace webTemplate.Global.Auth
{
    public interface IAuthCookieProvider
    {
        HttpCookie GetCookie(string cookieName);

        void SetCookie(HttpCookie cookie);
    }
}
