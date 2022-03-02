using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using Superhero.Logic;
using Superhero.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Superhero.ViewModels
{
    public class MainWindowViewModel:ObservableRecipient
    {
        ISuperHeroLogic logic;
        public ObservableCollection<SuperHeroMember> HeadQuarter { get; set; }
        public ObservableCollection<SuperHeroMember> BattleGround { get; set; }


        private SuperHeroMember super;

        public SuperHeroMember SelectedHeroFromHeadQuarter
        {
            get { return super; }
            set { 
                SetProperty(ref super, value);
                (AddToBattleGroundCommand as RelayCommand).NotifyCanExecuteChanged();
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
        public ICommand SaveCommand { get; set; }

        public double AVGPower
        {
            get {
                return logic.AVGPower;
            }
        }

        public double AVGSpeed
        {
            get {
                return logic.AVGSpeed;
            }
        }


        public static bool IsInDesignMode
        {
            get {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel():this(IsInDesignMode ? null:Ioc.Default.GetService<ISuperHeroLogic>())
        {

        }
        public MainWindowViewModel(ISuperHeroLogic logic)
        {
            this.logic = logic;
            HeadQuarter = new ObservableCollection<SuperHeroMember>();
            BattleGround = new ObservableCollection<SuperHeroMember>();

            if (File.Exists("HQ.json"))
            {
                var hq = JsonConvert.DeserializeObject<SuperHeroMember[]>(File.ReadAllText("HQ.json"));
                hq.ToList().ForEach(x => HeadQuarter.Add(x));
            }
            if (File.Exists("Battleground.json"))
            {
                var hq = JsonConvert.DeserializeObject<SuperHeroMember[]>(File.ReadAllText("Battleground.json"));
                hq.ToList().ForEach(x => BattleGround.Add(x));
            }
            logic.SetupCollections(HeadQuarter, BattleGround);


            AddToBattleGroundCommand = new RelayCommand(
                () => logic.AddToBattleground(SelectedHeroFromHeadQuarter),
                () => SelectedHeroFromHeadQuarter != null
                );

            RemoveFromBAttleGroundCommand = new RelayCommand(
                () => logic.RemoveFromBattleground(SelectedFromBattleground),
                () => SelectedFromBattleground != null
                );

            AddNewHeroCommand = new RelayCommand(
                () => logic.CreateHero(),
                () => true
                );
            SaveCommand = new RelayCommand(
                () => logic.SaveHeros(),
                () => true
                );

            Messenger.Register<MainWindowViewModel, string, string>(this, "Hero info", (recipient, msg) =>
            {
                OnPropertyChanged("AVGPower");
                OnPropertyChanged("AVGSpeed");
            });

        }

    }
}
