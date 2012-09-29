using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2WithoutDI
{
    class Program
    {
        static void Main(string[] args)
        {
            Warrior warrior = new Warrior(new Bazuka());
            warrior.Kill();
            Console.ReadLine();
        }
    }
}
