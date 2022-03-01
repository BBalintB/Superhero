using Superhero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero.ViewModels
{
    public class SuperHeroCreatorViewModel
    {
        public SuperHeroMember Shm { get; set; }

        public void Setup(SuperHeroMember shm)
        {
            Shm = shm;
        }

        public SuperHeroCreatorViewModel()
        {

        }

    }
}
