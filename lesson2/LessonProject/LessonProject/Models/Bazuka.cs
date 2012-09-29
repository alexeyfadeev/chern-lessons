using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LessonProject.Models
{
    public class Bazuka : IWeapon
    {
        public string Kill()
        {
            return "BIG BADABUM!";
        }
    }
}