using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonProject.Scaffolding
{
    /// <summary>
    /// This is LEGENDARY WARRIOR!
    /// </summary>
    public class Warrior
    {
        readonly IWeapon Weapon;

        public Warrior(IWeapon weapon)
        {
            this.Weapon = weapon;
        }

        public void Kill()
        {
            Weapon.Kill();
        }
    }
}
