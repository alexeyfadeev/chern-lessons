using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonProject.FacebookAPI
{
    public interface IFbAppConfig
    {
        string AppID { get; }

        string AppSecret { get; }
    }
}
