using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero.Models
{
    public enum Types { 
        good,bad,neutral
    }

    public class SuperHeroMember:ObservableObject
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name,value); }
        }

        private int power;

        public int Power
        {
            get { return power; }
            set { SetProperty(ref power, value); }
        }

        private int speed;

        public int Speed
        {
            get { return speed; }
            set { SetProperty(ref speed, value); }
        }

        private Types types;

        public Types Types
        {
            get { return types; }
            set { SetProperty(ref types, value); }
        }

        public SuperHeroMember GetCopy() {
            return new SuperHeroMember()
            {
                Name = this.Name,
                Power = this.Power,
                Speed = this.Speed,
                Types = this.Types
            };
        }


    }
}
