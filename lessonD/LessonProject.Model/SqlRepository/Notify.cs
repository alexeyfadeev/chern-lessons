using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LessonProject.Model
{
	
 public partial class SqlRepository
    {
        public IQueryable<Notify> Notifies
        {
            get
            {
                return Db.Notifies;
            }
        }

        public bool CreateNotify(Notify instance)
        {
            if (instance.ID == 0)
            {
                Db.Notifies.InsertOnSubmit(instance);
                Db.Notifies.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdateNotify(Notify instance)
        {
            var cache = Db.Notifies.FirstOrDefault(p => p.ID == instance.ID);
            if (cache != null)
            {
				cache.UserID = instance.UserID;
				cache.Message = instance.Message;
				cache.AddedDate = instance.AddedDate;
				cache.IsReaded = instance.IsReaded;
                Db.Notifies.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool RemoveNotify(int idNotify)
        {
            Notify instance = Db.Notifies.FirstOrDefault(p => p.ID == idNotify);
            if (instance != null)
            {
                Db.Notifies.DeleteOnSubmit(instance);
                Db.Notifies.Context.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}