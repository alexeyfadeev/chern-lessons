using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace Lesson2NinjectSample
{
    class Program
    {
        public static IKernel AppKernel;

        static void Main(string[] args)
        {
            AppKernel = new StandardKernel(new WeaponNinjectModule());
            
            var warrior = AppKernel.Get<Warrior>();
            warrior.Kill();

            var otherWarrior = new OtherWarrior();
            otherWarrior.Kill();


            var anotherWarrior = AppKernel.Get<AnotherWarrior>();
            anotherWarrior.Kill();

            Console.ReadLine();
        }
    }
}
