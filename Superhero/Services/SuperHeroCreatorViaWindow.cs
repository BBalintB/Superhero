using Superhero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero.Services
{
    public class SuperHeroCreatorViaWindow : ISuperHeroCreate
    {

        public SuperHeroMember Create()
        {
            SuperHeroMember tmp = new SuperHeroMember();
            new SuperHeroCreatorWindow(tmp).ShowDialog();

            if (tmp.Name != "")
            {
                return tmp;
            }
            return null;
        }
    }
}
