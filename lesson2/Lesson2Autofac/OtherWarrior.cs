﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2Autofac
{
    public class OtherWarrior
    {
        private IWeapon _weapon; 

        public IWeapon Weapon
        {
            get
            {
                if (_weapon == null)
                {
                   // _weapon = Program.AppKernel.Get<IWeapon>();
                }
                return _weapon;
            }
        }

        public void Kill()
        {
            Weapon.Kill();
        }
    }
}
