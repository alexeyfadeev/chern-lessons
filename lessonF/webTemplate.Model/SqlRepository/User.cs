using System;
using System.Collections.Generic;
using System.Linq;
using webTemplate.Tools;

namespace webTemplate.Model
{
    public partial class SqlRepository
    {
        public IQueryable<User> Users
        {
            get
            {
                return Db.Users;
            }
        }

        public bool CreateUser(User instance)
        {
            if (instance.ID == 0)
            {
                instance.AddedDate = DateTime.Now;
                instance.LastVisitDate = DateTime.Now;
                instance.ActivatedLink = StringExtension.GenerateNewFile();
                Db.Users.InsertOnSubmit(instance);
                Db.Users.Context.SubmitChanges();

                var lang = Db.Languages.FirstOrDefault(p => p.ID == instance.CurrentLang);
                if (lang != null)
                {
                    CreateOrChangeUserLang(instance, null, lang);
                    return true;
                }

                return true;
            }

            return false;
        }

        public User GetUser(string email)
        {
            return Db.Users.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0);
        }

        public User Login(string email, string password)
        {
            return Db.Users.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0 && p.Password == password);
        }

        public bool ChangeLanguage(User instance, string LangCode)
        {
            var cache = Db.Users.FirstOrDefault(p => p.ID == instance.ID);
            var newLang = Db.Languages.FirstOrDefault(p => p.Code == LangCode);
            if (cache != null && newLang != null)
            {
                cache.Language = newLang;
                Db.Users.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateUser(User instance)
        {
            var cache = Db.Users.FirstOrDefault(p => p.ID == instance.ID);
            if (cache != null)
            {
                cache.Email = instance.Email;
                cache.AvatarPath = instance.AvatarPath;
                Db.Users.Context.SubmitChanges();

                var lang = Db.Languages.FirstOrDefault(p => p.ID == instance.CurrentLang);
                if (lang != null)
                {
                    CreateOrChangeUserLang(instance, cache, lang);
                    return true;
                }

                return true;
            }
            return false;
        }

        public bool ActivateUser(User instance)
        {
            var cache = Db.Users.FirstOrDefault(p => p.ID == instance.ID);
            if (cache != null)
            {
                cache.ActivatedDate = DateTime.Now;
                Db.Users.Context.SubmitChanges();
                return true;
            }

            return false;
        }


        public bool ChangePassword(User instance)
        {
            var cache = Db.Users.FirstOrDefault(p => p.ID == instance.ID);
            if (cache != null)
            {
                cache.Password = instance.Password;
                Db.Users.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        private void CreateOrChangeUserLang(User instance, User cache, Language lang)
        {
            UserLang postLang = null;
            if (cache != null)
            {
                postLang = Db.UserLangs.FirstOrDefault(p => p.UserID == cache.ID && p.LanguageID == lang.ID);
            }
            if (postLang == null)
            {
                var newuserLang = new UserLang
                {
                    UserID = instance.ID,
                    LanguageID = lang.ID,
                    FirstName = instance.FirstName,
                    LastName = instance.LastName
                };
                Db.UserLangs.InsertOnSubmit(newuserLang);
            }
            else
            {
                postLang.FirstName = instance.FirstName;
                postLang.LastName = instance.LastName;
            }
            Db.UserLangs.Context.SubmitChanges();
        }
    }
}