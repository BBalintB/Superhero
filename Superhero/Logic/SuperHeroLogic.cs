using Microsoft.Toolkit.Mvvm.Messaging;
using Superhero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero.Logic
{
    public class SuperHeroLogic
    {
        IList<SuperHeroMember> headQuarter;
        IList<SuperHeroMember> battleground;
        IMessenger Messenger;
    }
}
