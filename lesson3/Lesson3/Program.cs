using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LessonProject.Model;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new LessonProjectDbDataContext(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            var roles = context.Roles.ToList();
            foreach (var role in roles)
            {
                Console.WriteLine("{0} {1} {2}", role.ID, role.Code, role.Name);
            }
            

            //var newRole = new Role
            //{
            //    Code = "manager", 
            //    Name = "Менеджер"
            //};
            //context.Roles.InsertOnSubmit(newRole);
            //context.Roles.Context.SubmitChanges();

            //var role = context.Roles.Where(p => p.Name == "Менеджер").FirstOrDefault();
            //if (role != null)
            //{
            //    context.Roles.DeleteOnSubmit(role);
            //    context.Roles.Context.SubmitChanges();
            //}

            //var role = context.Roles.Where(p => p.Name == "Менеджер").FirstOrDefault();
            //if (role != null)
            //{
            //    role.Name = "Манагер";
            //    context.Roles.Context.SubmitChanges();
            //}

            Console.ReadLine();
        }
    }
}
