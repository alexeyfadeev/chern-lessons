using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webTemplate.Model
{
    public interface IRepository
    {
        IQueryable<T> GetTable<T>() where T : class;

        #region Language

        IQueryable<Language> Languages { get; }

        bool CreateLanguage(Language instance);

        bool UpdateLanguage(Language instance);

        bool RemoveLanguage(int idLanguage);

        #endregion

        #region Role

        IQueryable<Role> Roles { get; }

        bool CreateRole(Role instance);

        bool RemoveRole(int idRole);

        #endregion

        #region User

        IQueryable<User> Users { get; }

        bool CreateUser(User instance);

        bool UpdateUser(User instance);

        User GetUser(string email);

        User Login(string email, string password);

        bool ChangeLanguage(User instance, string langCode);

        bool ActivateUser(User instance);

        bool ChangePassword(User instance);
        #endregion

        #region UserRole

        IQueryable<UserRole> UserRoles { get; }

        bool CreateUserRole(UserRole instance);

        bool RemoveUserRole(int idUserRole);

        #endregion
    }
}