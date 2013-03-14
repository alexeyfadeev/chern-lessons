using System.Collections.Generic;
using System.Web.Mvc;
using webTemplate.Model;

namespace webTemplate.Areas.Admin.Models.View
{
    public class LangAdminView
    {
        public List<SelectListItem> Langs { get; private set; }

        public LangAdminView(IRepository repository, string currentLang)
        {
            currentLang = currentLang ?? "";
            Langs = new List<SelectListItem>();

            foreach (var lang in repository.Languages)
            {
                Langs.Add(new SelectListItem
                              {
                    Selected = (string.Compare(currentLang, lang.Code, true) == 0),
                    Value = lang.Code,
                    Text = lang.Name
                });
            }
        }
    }
}