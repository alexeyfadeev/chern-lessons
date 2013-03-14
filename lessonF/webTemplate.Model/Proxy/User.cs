using System;
using System.Linq;
using ManageAttribute;

namespace webTemplate.Model
{
    public partial class User
    {
        public bool InRoles(string roles)
        {
            if (string.IsNullOrWhiteSpace(roles))
            {
                return false;
            }

            var rolesArray = roles.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
            foreach(var role in rolesArray)
            {
                var hasRole = UserRoles.Any(p => string.Compare(p.Role.Code, role, true) == 0);
                if (hasRole)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsActivated
        {
            get { return ActivatedDate.HasValue; }
        }

        public string FullAvatarPath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(AvatarPath))
                {
                    return "/Content/images/default_avatar.jpg";
                }
                return AvatarPath;
            }
        }

        private int _currentLang;

        public int CurrentLang
        {
            get
            {
                return _currentLang;
            }

            set
            {
                _currentLang = value;

                var currentLang = UserLangs.FirstOrDefault(p => p.LanguageID == value);
                if (currentLang == null)
                {
                    IsCorrectLang = false;
                    var anyLang = UserLangs.FirstOrDefault();
                    if (anyLang != null)
                    {
                        SetLang(anyLang);
                    }
                }
                else
                {
                    IsCorrectLang = true;
                    SetLang(currentLang);
                }
            }
        }

        public bool IsCorrectLang { get; protected set; }

        [LangColumn]
        public string FirstName { get; set; }

        [LangColumn]
        public string LastName { get; set; }

        private void SetLang(UserLang postLang)
        {
            FirstName = postLang.FirstName;
            LastName = postLang.LastName;
        }

    }
}