using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Lesson2CastleWindsor
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Register( Component.For<IWeapon>().ImplementedBy<Bazuka>(),
                Component.For<Warrior>().ImplementedBy<Warrior>());
            var warrior = container.Resolve<Warrior>();

            warrior.Kill();

            Console.ReadLine();
        }
    }
}
