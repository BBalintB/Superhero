using Superhero.Models;
using System.Collections.Generic;

namespace Superhero.Logic
{
    public interface ISuperHeroLogic
    {
        double AVGPower { get; }
        double AVGSpeed { get; }

        void AddToBattleground(SuperHeroMember member);
        void CreateHero();
        void RemoveFromBattleground(SuperHeroMember member);
        void SetupCollections(IList<SuperHeroMember> hQ, IList<SuperHeroMember> bF);
        void SaveHeros();
    }
}