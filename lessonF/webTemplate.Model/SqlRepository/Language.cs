using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace webTemplate.Model
{
    public partial class SqlRepository
    {
        public IQueryable<Language> Languages
        {
            get
            {
                return Db.Languages;
            }
        }

        public bool CreateLanguage(Language instance)
        {
            if (instance.ID == 0)
            {
                Db.Languages.InsertOnSubmit(instance);
                Db.Languages.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdateLanguage(Language instance)
        {
            var cache = Db.Languages.FirstOrDefault(p => p.ID == instance.ID);
            if (cache != null)
            {
                cache.Code = instance.Code;
                cache.Name = instance.Name;
                Db.Languages.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool RemoveLanguage(int idLanguage)
        {
            var instance = Db.Languages.FirstOrDefault(p => p.ID == idLanguage);
            if (instance != null)
            {
                Db.Languages.DeleteOnSubmit(instance);
                Db.Languages.Context.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
