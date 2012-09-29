using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2Autofac
{
    public class Bazuka : IWeapon
    {

        public void Kill()
        {
            Console.WriteLine("BIG BADABUM!");
        }
    }
}
