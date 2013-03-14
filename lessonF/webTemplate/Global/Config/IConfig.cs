using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace webTemplate.Global.Config
{
    public interface IConfig
    {
        string ConnectionStrings(string connectionString);

        string CultureCode { get; }

        CultureInfo Culture { get; }

        bool DebugMode { get;  }

        string AdminEmail { get;  }

        MailSetting MailSetting { get; }

        bool EnableMail { get; }

        IQueryable<MimeType> MimeTypes {  get; }

       

        IQueryable<MailTemplate> MailTemplates { get; }

        IQueryable<IconSize> IconSizes {get;}
    }
}
