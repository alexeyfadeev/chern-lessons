using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Lesson2Unity
{
    class Program
    {
        public static IUnityContainer Container;

        static void Main(string[] args)
        {
            Container = new UnityContainer();
            Container.RegisterType(typeof(IWeapon), typeof(Bazuka));

            var serviceProvider = new UnityServiceLocator(Container);
            ServiceLocator.SetLocatorProvider(() => serviceProvider);

            var warrior = Container.Resolve<Warrior>();
            warrior.Kill();

            var otherWarrior = new OtherWarrior();
            otherWarrior.Kill();

            Console.ReadLine();
        }
    }
}
