using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Superhero.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Superhero.ViewModels
{
    public class MainWindowViewModel:ObservableRecipient
    {

        public ObservableCollection<SuperHeroMember> HeadQuarter { get; set; }
        public ObservableCollection<SuperHeroMember> BattleGround { get; set; }


        private SuperHeroMember super;

        public SuperHeroMember SelectedHeroFromHeadQuarter
        {
            get { return super; }
            set { 
                SetProperty(ref super, value);
                (AddToBattleGroundCommand as RelayCommand).NotifyCanExecuteChanged();
                (AddNewHeroCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private SuperHeroMember fromBattleGround;

        public SuperHeroMember SelectedFromBattleground
        {
            get { return fromBattleGround; }
            set {
                SetProperty(ref fromBattleGround, value);
                (RemoveFromBAttleGroundCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }



        public ICommand AddToBattleGroundCommand { get; set; }
        public ICommand RemoveFromBAttleGroundCommand { get; set; }
        public ICommand AddNewHeroCommand { get; set; }

        public MainWindowViewModel()
        {
            HeadQuarter = new ObservableCollection<SuperHeroMember>();
            BattleGround = new ObservableCollection<SuperHeroMember>();

            HeadQuarter.Add(new SuperHeroMember()
            {
                Name = "Shazam",
                Power = 8,
                Speed = 8,
                Types = Types.good
            });
            HeadQuarter.Add(new SuperHeroMember()
            {
                Name = "Dr. Doom",
                Power = 6,
                Speed = 4,
                Types = Types.bad
            });
            HeadQuarter.Add(new SuperHeroMember()
            {
                Name = "Lois Lane",
                Power = 4,
                Speed = 2,
                Types = Types.neutral
            });

            //BattleGround.Add(HeadQuarter[2].GetCopy());
            //BattleGround.Add(HeadQuarter[4].GetCopy());
        }

    }
}
