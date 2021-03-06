using ManageAttribute;

namespace webTemplate.Models.ViewModels.User
{ 
	public class UserView : BaseUserView
    {
        public int CurrentLang { get; set; }

	    public bool IsCorrectLang { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

	    public string AvatarPath {get; set; }

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
    }

}