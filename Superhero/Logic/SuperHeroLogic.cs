using Microsoft.Toolkit.Mvvm.Messaging;
using Newtonsoft.Json;
using Superhero.Models;
using Superhero.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero.Logic
{
    public class SuperHeroLogic : ISuperHeroLogic
    {
        IList<SuperHeroMember> headQuarter;
        IList<SuperHeroMember> battleground;
        IMessenger Messenger;
        ISuperHeroCreate heroCreateService;
        public SuperHeroLogic(IMessenger messenger, ISuperHeroCreate superHeroCreate)
        {
            this.Messenger = messenger;
            this.heroCreateService = superHeroCreate;
        }
        public void SetupCollections(IList<SuperHeroMember> hQ, IList<SuperHeroMember> bF)
        {
            this.headQuarter = hQ;
            this.battleground = bF;
        }
        public double AVGPower
        {
            get
            {
                return Math.Round(battleground.Count == 0 ? 0 : battleground.Average(x => x.Power), 2);
            }
        }

        public double AVGSpeed
        {
            get
            {
                return Math.Round(battleground.Count == 0 ? 0 : battleground.Average(x => x.Speed), 2);
            }
        }

        public void AddToBattleground(SuperHeroMember member)
        {
            battleground.Add(member);
            Messenger.Send("Hero added ", "Hero info");
        }

        public void RemoveFromBattleground(SuperHeroMember member)
        {
            battleground.Remove(member);
            Messenger.Send("Hero removed", "Hero info");
        }

        public void CreateHero()
        {
            SuperHeroMember sH = heroCreateService.Create();
            if (sH!=null)
            {
                headQuarter.Add(sH);
            }
            
            
        }

        public void SaveHeros() {
            string jsonDataHQ = JsonConvert.SerializeObject(headQuarter);
            File.WriteAllText("HQ.json", jsonDataHQ);
            string jsonDataBattleground = JsonConvert.SerializeObject(battleground);
            File.WriteAllText("Battleground.json", jsonDataBattleground);
        }
    }
}
