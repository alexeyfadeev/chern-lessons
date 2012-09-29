using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Lesson2Autofac
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Bazuka>();
            builder.RegisterType<Warrior>();

            builder.Register<IWeapon>(x => x.Resolve<Bazuka>());

            var container = builder.Build();

            var warrior = container.Resolve<Warrior>();
            warrior.Kill();

            Console.ReadLine();
        }
    }
}
