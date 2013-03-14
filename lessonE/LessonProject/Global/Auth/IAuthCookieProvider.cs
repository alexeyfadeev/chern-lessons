using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LessonProject.Global.Auth
{
    public interface IAuthCookieProvider
    {
        HttpCookie GetCookie(string cookieName);

        void SetCookie(HttpCookie cookie);
    }
}
